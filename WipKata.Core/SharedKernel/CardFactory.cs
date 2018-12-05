using WipKata.Core.Entities;
using WipKata.Core.Interfaces;

namespace WipKata.Core.SharedKernel
{
    public class CardFactory : ICardFactory
    {
        private readonly ITimerFactory _cardTimerFactory;
        private readonly IDotFactory _dotFactory;

        public CardFactory(ITimerFactory cardTimerFactory, IDotFactory dotFactory)
        {
            _cardTimerFactory = cardTimerFactory;
            _dotFactory = dotFactory;
        }

        public ICard CreateCard(int cardNumber, bool isSpecialCard)
        {
            var name = $"Card #{cardNumber}";

            return new Card(name, 
                _cardTimerFactory.CreateTimer($"{name} Timer", isSpecialCard), 
                _dotFactory.CreateCardDots());
        }
    }
}