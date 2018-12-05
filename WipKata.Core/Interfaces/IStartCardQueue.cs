namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents a queue of <see cref="ICard"/> instances for the
    /// first card queue in a work process.
    /// </summary>
    public interface IStartCardQueue : ICardQueue, ICardProvider
    {
        /// <summary>
        /// Provide the starting queue's total card count to a card handler.
        /// </summary>
        /// <param name="cardHandler"><see cref="ICardHandler"/> instance</param>
        void ProvideTotalCardCount(ICardHandler cardHandler);

        /// <summary>
        /// Subscribe to a card recipient.
        /// </summary>
        /// <param name="cardRecipient"><see cref="ICardRecipient"/> instance</param>
        void Subscribe(ICardRecipient cardRecipient);
    }
}