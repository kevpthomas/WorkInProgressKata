namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents a timer mechanism for tracking work in progress.
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// The number of elapsed seconds since the timer was started.
        /// </summary>
        double ElapsedSeconds { get; }

        /// <summary>
        /// Timer identifier.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the timer.
        /// </summary>
        void Stop();
    }
}