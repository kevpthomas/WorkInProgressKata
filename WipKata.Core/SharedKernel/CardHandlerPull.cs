using System.Collections.Generic;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class CardHandlerPull : CardHandler, ICardProvider, ICardRecipient
    {
        private ICardProvider _nextCardProvider;
        private ICardRecipient _activeCardRecipient;

        private bool _isNextCardReady;
        private readonly Queue<ICard> _activeQueue = new Queue<ICard>();

        public CardHandlerPull(HandlerType type,
            uint millisecondsPerSticker,
            ITimer cardHandlerTimer)
            : base(type, millisecondsPerSticker, cardHandlerTimer)
        { }
                        
        public void SubscribeNext(ICardRecipient cardRecipient)
        {
            _activeCardRecipient = cardRecipient;
        }
                        
        public void SubscribePrevious(ICardProvider cardProvider)
        {
            _nextCardProvider = cardProvider;
        }

        public void NotifyNextCardIsReady()
        {
            _isNextCardReady = true;
        }

        public ICard PassCard()
        {
            return _activeQueue.Dequeue();
        }
        
        protected override bool ProcessCard()
        {
            if (!_isNextCardReady || _activeQueue.Count > 0) return false;

            _isNextCardReady = false;

            var activeCard = _nextCardProvider.PassCard();

            AddStickersToActiveCard(activeCard);

            _activeQueue.Enqueue(activeCard);
            _activeCardRecipient.NotifyNextCardIsReady();

            return true;
        }
    }
}