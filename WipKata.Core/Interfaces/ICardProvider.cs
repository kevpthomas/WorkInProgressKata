namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares a work in progress card provider.
    /// </summary>
    public interface ICardProvider
    {
        /// <summary>
        /// Output an <see cref="ICard"/> instance.
        /// </summary>
        /// <returns>An <see cref="ICard"/> instance.</returns>
        ICard PassCard();
    }
}