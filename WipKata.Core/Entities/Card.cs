using System.Collections.Generic;
using System.Linq;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.Entities
{
    public class Card : ICard
    {
        private readonly IEnumerable<Dot> _dots;

        public Card(string name, ITimer cardTimer, IEnumerable<Dot> dots)
        {
            Name = name;
            CardTimer = cardTimer;
            _dots = dots;
        }

        public string Name { get; }

        public void AddSticker(HandlerType type)
        {
            var emptyDot = _dots.FirstOrDefault(x => x.Type == type && !x.HasSticker);

            if (emptyDot != null)
            {
                emptyDot.HasSticker = true;
            }
        }

        public bool IsMissingStickers(HandlerType type)
        {
            return _dots.Any(x => x.Type == type && !x.HasSticker);
        }

        public ITimer CardTimer { get; }

        public void ResetCard()
        {
            foreach (var dot in _dots)
            {
                dot.HasSticker = false;
            }
        }
    }
}