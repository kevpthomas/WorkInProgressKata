namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Represents methods for creating <see cref="ITimer"/> instances.
    /// </summary>
    public interface ITimerFactory
    {
        /// <summary>
        /// Creates a timer. 
        /// </summary>
        /// <param name="name">Timer identifier.</param>
        /// <returns><see cref="ITimer"/> instance.</returns>
        ITimer CreateTimer(string name);

        /// <summary>
        /// Creates a timer and declares if it should report on timer actions.
        /// </summary>
        /// <param name="name">Timer identifier.</param>
        /// <param name="isReportTimerActions">true to report on timer actions; otherwise false</param>
        /// <returns><see cref="ITimer"/> instance.</returns>
        ITimer CreateTimer(string name, bool isReportTimerActions);
    }
}