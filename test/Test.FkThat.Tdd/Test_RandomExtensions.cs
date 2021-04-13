using System;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace FkThat.Tdd
{
    public class Test_RandomExtensions
    {
        [Theory]
        [InlineData(0x00, 0x00, 0x00, 0x00, 0)]
        [InlineData(0x42, 0x69, 0x42, 0x69, 1765960002)]
        [InlineData(0xff, 0xff, 0xff, 0xff, 2147483646)]
        public void Next_ShouldReturnRandomInt(
            byte a, byte b, byte c, byte d, int expected)
        {
            var rand = A.Fake<IRandom>();

            A.CallTo(() => rand.NextBytes(A<byte[]>._))
                .Invokes((byte[] buf) => {
                    buf[0] = a;
                    buf[1] = b;
                    buf[2] = c;
                    buf[3] = d;
                });

            var r = rand.Next();
            r.Should().Be(expected);
        }

        [Theory]
        [InlineData(0x00, 0x00, 0x00, 0x00, 0d)]
        [InlineData(0x42, 0x69, 0x42, 0x69, 0.82233920824822937d)]
        [InlineData(0xff, 0xff, 0xff, 0xff, 0.99999999953433871d)]
        public void NextDouble_ShouldReturnRandomDouble(
            byte a, byte b, byte c, byte d, double expected)
        {
            var rand = A.Fake<IRandom>();

            A.CallTo(() => rand.NextBytes(A<byte[]>._))
                .Invokes((byte[] buf) => {
                    buf[0] = a;
                    buf[1] = b;
                    buf[2] = c;
                    buf[3] = d;
                });

            var r = rand.NextDouble();
            r.Should().Be(expected);
        }

        [Fact]
        public void Next_WithUpperBound_ShouldValidateBound()
        {
            var rand = A.Fake<IRandom>();
            rand.Invoking(r => r.Next(-42)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0x00, 0x00, 0x00, 0x00, 0)]
        [InlineData(0x42, 0x69, 0x42, 0x69, 34)]
        [InlineData(0xff, 0xff, 0xff, 0xff, 41)]
        public void Next_WithUpperBound_ShouldReturnRandomInt(
            byte a, byte b, byte c, byte d, int expected)
        {
            var rand = A.Fake<IRandom>();

            A.CallTo(() => rand.NextBytes(A<byte[]>._))
                .Invokes((byte[] buf) => {
                    buf[0] = a;
                    buf[1] = b;
                    buf[2] = c;
                    buf[3] = d;
                });

            var r = rand.Next(42);
            r.Should().Be(expected);
        }

        [Fact]
        public void Next_WithLowerUpperBound_ShouldValidateBounds()
        {
            var rand = A.Fake<IRandom>();
            rand.Invoking(r => r.Next(69, 42)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0x00, 0x00, 0x00, 0x00, 42)]
        [InlineData(0x42, 0x69, 0x42, 0x69, 64)]
        [InlineData(0xff, 0xff, 0xff, 0xff, 68)]
        public void Next_WithLowerUpperBound_ShouldReturnRandomInt(
            byte a, byte b, byte c, byte d, int expected)
        {
            var rand = A.Fake<IRandom>();

            A.CallTo(() => rand.NextBytes(A<byte[]>._))
                .Invokes((byte[] buf) => {
                    buf[0] = a;
                    buf[1] = b;
                    buf[2] = c;
                    buf[3] = d;
                });

            var r = rand.Next(42, 69);
            r.Should().Be(expected);
        }
    }
}
