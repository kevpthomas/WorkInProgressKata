namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents a queue of <see cref="ICard"/> instances for the
    /// last card queue in a work process.
    /// </summary>
    public interface IEndCardQueue : ICardQueue, ICardRecipient
    {
        /// <summary>
        /// Functionality to subscribe to an <see cref="ICardProvider"/> instance.
        /// </summary>
        /// <param name="cardProvider"><see cref="ICardProvider"/> instance</param>
        void Subscribe(ICardProvider cardProvider);
    }
}