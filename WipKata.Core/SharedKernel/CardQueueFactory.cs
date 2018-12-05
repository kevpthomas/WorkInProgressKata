using System.Collections.Generic;
using WipKata.Core.Interfaces;

namespace WipKata.Core.SharedKernel
{
    public class CardQueueFactory : ICardQueueFactory
    {
        public ICardQueue CreateCardQueue()
        {
            return new CardQueue();
        }

        public IEndCardQueue CreateEndCardQueue()
        {
            return new EndCardQueue();
        }

        public IStartCardQueue CreateStartCardQueue(IEnumerable<ICard> cardsToEnqueue)
        {
            return new StartCardQueue(cardsToEnqueue);
        }
    }
}