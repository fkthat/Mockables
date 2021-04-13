using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace FkThat.Tdd
{
    public class Test_SystemClock
    {
        [Fact]
        public async Task UtcNow_ShouldReturnIncrementalTime()
        {
            SystemClock sut = new();

            List<DateTimeOffset> r = new();

            for (var i = 0; i < 16; i++)
            {
                r.Add(sut.UtcNow);
                await Task.Delay(1);
            }

            r.Should().BeInAscendingOrder();
        }

        [Fact]
        public void UtcNow_ShouldReturnUtcTime()
        {
            SystemClock sut = new();
            var r = sut.UtcNow;
            r.Offset.Should().Be(TimeSpan.Zero);
        }
    }
}
