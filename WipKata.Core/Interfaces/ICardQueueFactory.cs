using System.Collections.Generic;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents methods for creating card queue instances.
    /// </summary>
    public interface ICardQueueFactory
    {
        /// <summary>
        /// Create an instance of <see cref="ICardQueue"/>
        /// </summary>
        /// <returns>An instance of <see cref="ICardQueue"/></returns>
        ICardQueue CreateCardQueue();

        /// <summary>
        /// Create an instance of <see cref="IEndCardQueue"/>
        /// </summary>
        /// <returns>An instance of <see cref="IEndCardQueue"/></returns>
        IEndCardQueue CreateEndCardQueue();

        /// <summary>
        /// Create an instance of <see cref="IStartCardQueue"/>
        /// </summary>
        /// <param name="cardsToEnqueue"><see cref="ICard"/> collection used to initialise a starting queue</param>
        /// <returns>An instance of <see cref="IStartCardQueue"/></returns>
        IStartCardQueue CreateStartCardQueue(IEnumerable<ICard> cardsToEnqueue);
    }
}