using System;

namespace FkThat.Mockables
{
    public interface IClock
    {
        DateTimeOffset UtcNow { get; }
    }
}
