using System.Linq;
using System.Security.Cryptography;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace FkThat.Mockables
{
    public class Test_Random
    {
        [Fact]
        public void NextBytes_ShouldCallRandomGenerator()
        {
            var buffer = new byte[2];
            var rng = A.Fake<RandomNumberGenerator>();

            A.CallTo(() => rng.GetBytes(buffer)).Invokes(c => {
                buffer[0] = 0x42;
                buffer[1] = 0x69;
            });

            Random sut = new(rng);
            sut.NextBytes(buffer);
            buffer.Should().Equal(0x42, 0x69);
        }

        [Fact]
        public void Dispose_ShouldCallRandomNumberGenerator()
        {
            var rng = A.Fake<RandomNumberGenerator>();
            Random sut = new(rng);
            sut.Dispose();
            A.CallTo(rng).Where(c => c.Method.Name == "Dispose").MustHaveHappened();
        }
    }
}
