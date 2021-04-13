using System;
using System.Security.Cryptography;

namespace FkThat.Mockables
{
    /// <summary>
    /// Random number generator.
    /// </summary>
    public sealed class Random : IRandom, IDisposable
    {
        private readonly RandomNumberGenerator _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Random"/> class.
        /// </summary>
        public Random()
        {
            _random = RandomNumberGenerator.Create();
        }

        /// <summary>
        /// For testing.
        /// </summary>
        internal Random(RandomNumberGenerator random)
        {
            _random = random;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _random.Dispose();
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        /// <exception cref="ArgumentNullException">buffer is null.</exception>
        public void NextBytes(byte[] buffer) => _random.GetBytes(buffer);
    }
}
