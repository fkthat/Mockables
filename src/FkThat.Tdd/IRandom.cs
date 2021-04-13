using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FkThat.Tdd
{
    /// <summary>
    /// Random number generator.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        /// <exception cref="ArgumentNullException">buffer is null.</exception>
        void NextBytes(byte[] buffer);
    }
}
