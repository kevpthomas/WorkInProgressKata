namespace WipKata.Core.Types
{
    /// <summary>
    /// Type of card queue.
    /// </summary>
    public enum CardQueueType
    {
        /// <summary>
        /// Standard card queue
        /// </summary>
        Normal,

        /// <summary>
        /// The first card queue in a work process
        /// </summary>
        Start,

        /// <summary>
        /// The last card queue in a work process
        /// </summary>
        End
    }
}