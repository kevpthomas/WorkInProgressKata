using System.Collections.Generic;
using System.Linq;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class StartCardQueue : CardQueue, IStartCardQueue
    {
        private readonly int _totalCardCount;
        private ICardRecipient _cardRecipient;

        public StartCardQueue(IEnumerable<ICard> cardsToEnqueue)
            : base(CardQueueType.Start)
        {
            var cardsToEnqueueList = cardsToEnqueue.ToList();
            _totalCardCount = cardsToEnqueueList.Count;

            foreach (var card in cardsToEnqueueList)
            {
                card.ResetCard();
                Enqueue(card);
            }
        }

        public void ProvideTotalCardCount(ICardHandler cardHandler)
        {
            cardHandler?.SetTotalCardCount(_totalCardCount);
        }
                
        public void Subscribe(ICardRecipient cardRecipient)
        {
            _cardRecipient = cardRecipient;
            _cardRecipient?.NotifyNextCardIsReady();
        }

        public ICard PassCard()
        {
            _cardRecipient?.NotifyNextCardIsReady();
            return Dequeue();
        }
    }
}