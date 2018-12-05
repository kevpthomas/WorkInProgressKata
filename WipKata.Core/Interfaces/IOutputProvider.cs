namespace WipKata.Core.Interfaces
{
    /// <summary>
    /// Declares methods for outputting the results of processing runs.
    /// </summary>
    public interface IOutputProvider
    {
        /// <summary>
        /// Outputs the specified string value.
        /// </summary>
        /// <param name="value">The value to output.</param>
        void OutputLine(string value);

        /// <summary>
        /// Outputs the text representation of the specified object,
        /// using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to output using format.</param>
        void OutputLine(string format, object arg0);

        /// <summary>
        /// Outputs a blank line.
        /// </summary>
        void OutputLine();
    }
}