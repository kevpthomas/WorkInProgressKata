namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares a work in progress card recipient.
    /// </summary>
    public interface ICardRecipient
    {
        /// <summary>
        /// Notify the recipient that the next work in progress card is ready for processing.
        /// </summary>
        void NotifyNextCardIsReady();
    }
}