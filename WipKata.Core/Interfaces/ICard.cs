using WipKata.Core.Types;

namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents a unit of work card.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Timer used to record actions on this card.
        /// </summary>
        ITimer CardTimer { get; }

        /// <summary>
        /// Card name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Add a sticker to this card for the supplied sticker type.
        /// </summary>
        /// <param name="type">Type of sticker to add to the card.</param>
        void AddSticker(HandlerType type);

        /// <summary>
        /// Checks if the card has uncovered dots for the supplied sticker type.
        /// </summary>
        /// <param name="type">Type of sticker to check.</param>
        /// <returns>true if there are uncovered dots for the supplied sticker type; otherwise false</returns>
        bool IsMissingStickers(HandlerType type);

        /// <summary>
        /// Resets the card to have all uncovered dots.
        /// </summary>
        void ResetCard();
    }
}