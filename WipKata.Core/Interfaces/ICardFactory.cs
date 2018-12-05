namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares a factory for creating <see cref="ICard"/> instances.
    /// </summary>
    public interface ICardFactory
    {
        /// <summary>
        /// Create an instance of <see cref="ICard"/>.
        /// </summary>
        /// <param name="cardNumber">Unique id number for the card.</param>
        /// <param name="isSpecialCard">true if this is a special card</param>
        /// <returns>An instance of <see cref="ICard"/></returns>
        ICard CreateCard(int cardNumber, bool isSpecialCard);
    }
}