using System;
using FluentAssertions;
using Xunit;

namespace FkThat.Tdd
{
    public class Test_ConsoleAdapterWrapper
    {
        [Fact]
        public void In_ShouldReturneConsoleIn()
        {
            ConsoleAdapter sut = new();
            sut.In.Should().Be(Console.In);
        }

        [Fact]
        public void Out_ShouldReturneConsoleOut()
        {
            ConsoleAdapter sut = new();
            sut.Out.Should().Be(Console.Out);
        }

        [Fact]
        public void Error_ShouldReturneConsoleError()
        {
            ConsoleAdapter sut = new();
            sut.Error.Should().Be(Console.Error);
        }
    }
}
