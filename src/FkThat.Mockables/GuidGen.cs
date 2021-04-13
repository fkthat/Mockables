using System;

namespace FkThat.Mockables
{
    internal class GuidGen : IGuidGen
    {
        public Guid NewGuid() => Guid.NewGuid();
    }
}
