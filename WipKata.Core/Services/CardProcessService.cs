using System.Collections.Generic;
using WipKata.Core.Entities;
using WipKata.Core.Interfaces;
using WipKata.Core.SharedKernel;
using WipKata.Core.Types;

namespace WipKata.Core.Services
{
    public class CardProcessService : ICardProcessService
    {
        private readonly ITimerFactory _timerFactory;
        private readonly ICardQueueFactory _cardQueueFactory;
        private readonly List<ICard> _allCards;
        private readonly uint _millisecondsPerSticker;

        public CardProcessService(ICardFactory cardFactory, 
            ITimerFactory timerFactory, 
            ICardQueueFactory cardQueueFactory,
            int? numberOfCards = null, 
            uint millisecondsPerSticker = 100)
        {
            _timerFactory = timerFactory;
            _cardQueueFactory = cardQueueFactory;
            _millisecondsPerSticker = millisecondsPerSticker;

            var totalCardCount = numberOfCards ?? 20;

            _allCards = new List<ICard>(totalCardCount);

            for (var i = 1; i <= totalCardCount; i++)
            {
                _allCards.Add(cardFactory.CreateCard(i, i == 1 || i == totalCardCount));
            }
        }

        public IEnumerable<ICardHandler> GetCardHandlers(WipType sequenceType)
        {
            return sequenceType == WipType.Push ? PushSequence() : PullSequence();
        }

        private IEnumerable<ICardHandler> PushSequence()
        {
            var startQueue = CreateStartQueue();

            var betaInQueue = _cardQueueFactory.CreateCardQueue();
            var alphaCardHandler = CreateCardHandlerPush(HandlerType.Alpha, startQueue, betaInQueue);

            var gammaInQueue = _cardQueueFactory.CreateCardQueue();
            var betaCardHandler = CreateCardHandlerPush(HandlerType.Beta, betaInQueue, gammaInQueue);

            var deltaInQueue = _cardQueueFactory.CreateCardQueue();
            var gammaCardHandler = CreateCardHandlerPush(HandlerType.Gamma, gammaInQueue, deltaInQueue);

            var endQueue = _cardQueueFactory.CreateEndCardQueue();
            var deltaCardHandler = CreateCardHandlerPush(HandlerType.Delta, deltaInQueue, endQueue);

            startQueue.ProvideTotalCardCount(alphaCardHandler);
            startQueue.ProvideTotalCardCount(betaCardHandler);
            startQueue.ProvideTotalCardCount(gammaCardHandler);
            startQueue.ProvideTotalCardCount(deltaCardHandler);

            return new ICardHandler[]
            {
                alphaCardHandler, 
                betaCardHandler,
                gammaCardHandler, 
                deltaCardHandler
            };
        }

        private IEnumerable<ICardHandler> PullSequence()
        {
            var startQueue = CreateStartQueue();
            var endQueue = _cardQueueFactory.CreateEndCardQueue();

            var alphaCardHandler = CardHandlerPull(HandlerType.Alpha);
            var betaCardHandler = CardHandlerPull(HandlerType.Beta);
            var gammaCardHandler = CardHandlerPull(HandlerType.Gamma);
            var deltaCardHandler = CardHandlerPull(HandlerType.Delta);
            
            alphaCardHandler.SubscribePrevious(startQueue);
            alphaCardHandler.SubscribeNext(betaCardHandler);
            betaCardHandler.SubscribePrevious(alphaCardHandler);
            betaCardHandler.SubscribeNext(gammaCardHandler);
            gammaCardHandler.SubscribePrevious(betaCardHandler);
            gammaCardHandler.SubscribeNext(deltaCardHandler);
            deltaCardHandler.SubscribePrevious(gammaCardHandler);
            deltaCardHandler.SubscribeNext(endQueue);

            startQueue.ProvideTotalCardCount(alphaCardHandler);
            startQueue.ProvideTotalCardCount(betaCardHandler);
            startQueue.ProvideTotalCardCount(gammaCardHandler);
            startQueue.ProvideTotalCardCount(deltaCardHandler);

            startQueue.Subscribe(alphaCardHandler);
            endQueue.Subscribe(deltaCardHandler);

            return new ICardHandler[]
            {
                alphaCardHandler, 
                betaCardHandler,
                gammaCardHandler, 
                deltaCardHandler
            };
        }

        private IStartCardQueue CreateStartQueue()
        {
            return _cardQueueFactory.CreateStartCardQueue(_allCards);
        }

        private CardHandlerPush CreateCardHandlerPush(HandlerType type, ICardQueue inQueue, ICardQueue outQueue)
        {
            return new CardHandlerPush(type,
                _millisecondsPerSticker, 
                _timerFactory.CreateTimer(TimerName(type)),
                inQueue, 
                outQueue);
        }

        private CardHandlerPull CardHandlerPull(HandlerType type)
        {
            return new CardHandlerPull(type,
                _millisecondsPerSticker, 
                _timerFactory.CreateTimer(TimerName(type)));
        }

        private static string TimerName(HandlerType type)
        {
            return $"Card Handler {type}";
        }
    }
}