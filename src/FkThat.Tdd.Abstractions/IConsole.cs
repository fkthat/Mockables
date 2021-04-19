using System.IO;

namespace FkThat.Tdd
{
    /// <summary>
    /// Console abstraction.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Gets the standard output stream.
        /// </summary>
        TextWriter Out { get; }

        /// <summary>
        /// Gets the standard error stream.
        /// </summary>
        TextWriter Error { get; }

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        TextReader In { get; }
    }
}
