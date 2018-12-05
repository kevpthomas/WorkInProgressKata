using System;
using System.Collections.Generic;
using System.Linq;
using WipKata.Core.Entities;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Core.SharedKernel
{
    public class DotFactory : IDotFactory
    {
        private const int DotCount = 15;

        private static readonly Random Random = new Random();


        public IEnumerable<Dot> CreateCardDots()
        {
            var dots = new List<Dot>(DotCount);

            var remainingDots = DotCount;

            foreach (var handlerType in Enum.GetValues(typeof(HandlerType)).Cast<HandlerType>().Where(e => e != HandlerType.Delta))
            {
                var dotCount = Random.Next(1, 3);
                remainingDots -= dotCount;
                for (var i = 0; i < dotCount; i++)
                {
                    dots.Add(new Dot(handlerType));
                }
            }

            for (var i = 0; i < remainingDots; i++)
            {
                dots.Add(new Dot(HandlerType.Delta));
            }

            return dots;
        }
    }
}