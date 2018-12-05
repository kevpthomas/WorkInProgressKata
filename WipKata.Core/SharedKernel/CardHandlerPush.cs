using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class CardHandlerPush : CardHandler
    {
        private readonly ICardQueue _inQueue;
        private readonly ICardQueue _outQueue;

        public CardHandlerPush(HandlerType type, 
            uint millisecondsPerSticker,
            ITimer cardHandlerTimer, 
            ICardQueue inQueue, 
            ICardQueue outQueue)
            : base(type, millisecondsPerSticker, cardHandlerTimer)
        {
            _inQueue = inQueue;
            _outQueue = outQueue;
        }

        protected override bool ProcessCard()
        {
            if (_inQueue.Count == 0) return false;

            var activeCard = _inQueue.Dequeue();

            AddStickersToActiveCard(activeCard);

            _outQueue.Enqueue(activeCard);

            return true;
        }
    }
}