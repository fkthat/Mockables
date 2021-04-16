using System;

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

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less
        /// than 1.0.
        /// </summary>
        /// <returns>
        /// A double-precision floating point number that is greater than or equal to 0.0, and less
        /// than 1.0.
        /// </returns>
        double NextDouble() => (double)Next() / int.MaxValue;

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">
        /// The exclusive upper bound of the random number to be generated. maxValue must be greater
        /// than or equal to 0.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to 0, and less than maxValue; that
        /// is, the range of return values ordinarily includes 0 but not maxValue. However, if
        /// maxValue equals 0, maxValue is returned.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">maxValue is less than 0.</exception>
        int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxValue),
                    $"'{nameof(maxValue)}' must be greater than zero.");
            }

            return (int)(NextDouble() * maxValue);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">
        /// The exclusive upper bound of the random number returned. maxValue must be greater than
        /// or equal to minValue.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer greater than or equal to minValue and less than maxValue; that
        /// is, the range of return values includes minValue but not maxValue. If minValue equals
        /// maxValue, minValue is returned.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// minValue is greater than maxValue.
        /// </exception>
        int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(minValue),
                    $"'{nameof(minValue)}' cannot be greater than {nameof(maxValue)}.");
            }

            return minValue + Next(maxValue - minValue);
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to 0 and less than <c
        /// cref="int.MaxValue"/>.
        /// </returns>
        int Next()
        {
            var buffer = new byte[4];
            NextBytes(buffer);
            buffer[3] &= 0x7f;
            var n = (buffer[3] << 24) | (buffer[2] << 16) | (buffer[1] << 8) | buffer[0];
            return n < int.MaxValue ? n : (n - 1);
        }
    }
}
