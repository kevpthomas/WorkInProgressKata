using WipKata.Core.Types;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares methods for handling cards.
    /// </summary>
    public interface ICardHandler
    {
        /// <summary>
        /// Describes the type of card handler.
        /// </summary>
        HandlerType Type { get; }

        /// <summary>
        /// Apply stickers to all dots on all cards supplied.
        /// </summary>
        void ApplyStickersToDots();

        /// <summary>
        /// Set the total count of cards to be processed.
        /// </summary>
        /// <param name="totalCardCount">Total card count.</param>
        void SetTotalCardCount(int totalCardCount);
    }
}