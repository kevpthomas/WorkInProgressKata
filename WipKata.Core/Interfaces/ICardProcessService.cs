using System.Collections.Generic;
using WipKata.Core.Types;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares a service to provide a card processing run.
    /// </summary>
    public interface ICardProcessService
    {
        /// <summary>
        /// Retrieves a collection of <see cref="ICardHandler"/> instances.
        /// </summary>
        /// <param name="sequenceType">Type of work in progress processing sequence to create.</param>
        /// <returns>A collection of <see cref="ICardHandler"/> instances to perform the provided WIP processing sequence.</returns>
        IEnumerable<ICardHandler> GetCardHandlers(WipType sequenceType);
    }
}