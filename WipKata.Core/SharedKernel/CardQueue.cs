using System.Collections.Generic;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class CardQueue : ICardQueue
    {
        private readonly Queue<ICard> _queue = new Queue<ICard>();
        public CardQueueType Type { get; }

        public CardQueue()
            : this(CardQueueType.Normal)
        {}

        protected CardQueue(CardQueueType type)
        {
            Type = type;
        }

        public void Enqueue(ICard item)
        {
            _queue.Enqueue(item);
            if (Type == CardQueueType.End) item.CardTimer.Stop();
        }

        public ICard Dequeue()
        {
            var item = _queue.Dequeue();
            if (Type == CardQueueType.Start) item.CardTimer.Start();
            return item;
        }

        public int Count => _queue.Count;
    }
}