using System.Collections.Generic;
using WipKata.Core.Entities;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents methods for creating card dots.
    /// </summary>
    public interface IDotFactory
    {
        /// <summary>
        /// Create a collection of <see cref="Dot"/> instances.
        /// </summary>
        /// <returns>A collection of <see cref="Dot"/> instances for an <see cref="ICard"/></returns>
        IEnumerable<Dot> CreateCardDots();
    }
}