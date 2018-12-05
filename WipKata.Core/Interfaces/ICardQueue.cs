using WipKata.Core.Types;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents a queue of <see cref="ICard"/> instances.
    /// </summary>
    public interface ICardQueue
    {
        /// <summary>
        /// Number of cards in the queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Type of card queue
        /// </summary>
        CardQueueType Type { get; }

        /// <summary>
        /// Removes and returns the card at the beginning of the <see cref="ICardQueue"/>
        /// </summary>
        /// <returns></returns>
        ICard Dequeue();

        /// <summary>
        /// Adds a card to the end of the <see cref="ICardQueue"/>
        /// </summary>
        /// <param name="item">Card to add to the queue</param>
        void Enqueue(ICard item);
    }
}