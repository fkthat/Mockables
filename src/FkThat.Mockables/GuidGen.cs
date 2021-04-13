using System;

namespace FkThat.Mockables
{
    /// <summary>
    /// GUID generator.
    /// </summary>
    public class GuidGen : IGuidGen
    {
        /// <summary>
        /// Initializes a new instance of the System.Guid structure.
        /// </summary>
        /// <returns>A new GUID object.</returns>
        public Guid NewGuid() => Guid.NewGuid();
    }
}
