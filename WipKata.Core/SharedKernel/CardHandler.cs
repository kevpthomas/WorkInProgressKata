using System.Threading;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public abstract class CardHandler : ICardHandler
    {
        private readonly int _millisecondsPerSticker;
        private readonly ITimer _cardHandlerTimer;

        private int _totalCardCount;
        private int _processedCardCount;

        protected CardHandler(HandlerType type, uint millisecondsPerSticker, ITimer cardHandlerTimer)
        {
            Type = type;
            _millisecondsPerSticker = (int)millisecondsPerSticker;
            _cardHandlerTimer = cardHandlerTimer;
        }

        public void ApplyStickersToDots()
        {
            _cardHandlerTimer.Start();

            while (_processedCardCount < _totalCardCount)
            {
                if (!ProcessCard()) continue;

                _processedCardCount += 1;
            }

            _cardHandlerTimer.Stop();
        }

        public void SetTotalCardCount(int totalCardCount)
        {
            _totalCardCount = totalCardCount;
        }

        public HandlerType Type { get; }

        protected abstract bool ProcessCard();

        protected void AddStickersToActiveCard(ICard activeCard)
        {
            while (activeCard.IsMissingStickers(Type))
            {
                Thread.Sleep(_millisecondsPerSticker);
                activeCard.AddSticker(Type);
            }
        }
    }
}