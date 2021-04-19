using System;
using System.IO;

namespace FkThat.Tdd
{
    /// <summary>
    /// Wrapper to the <c cref="Console"/> class implementing the <c cref="IConsole"/> interface.
    /// </summary>
    public class ConsoleAdapter : IConsole
    {
        /// <summary>
        /// Gets the standard output stream.
        /// </summary>
        public TextWriter Out => Console.Out;

        /// <summary>
        /// Gets the standard error stream.
        /// </summary>
        public TextWriter Error => Console.Error;

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        public TextReader In => Console.In;
    }
}
