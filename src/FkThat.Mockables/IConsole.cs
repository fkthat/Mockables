using System.Diagnostics.CodeAnalysis;

namespace FkThat.Mockables
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
        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
            Justification = "Named to replicate System.Console API.")]
        TextWriter Error { get; }

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
            Justification = "Named to replicate System.Console API.")]
        TextReader In { get; }
    }
}
