using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class EndCardQueue : CardQueue, IEndCardQueue
    {
        private ICardProvider _cardProvider;

        public EndCardQueue()
            : base(CardQueueType.End)
        { }
        
        public void Subscribe(ICardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        public void NotifyNextCardIsReady()
        {
            if (_cardProvider != null) Enqueue(_cardProvider.PassCard());
        }
    }
}