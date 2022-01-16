using System.Security.Cryptography;

namespace FkThat.Mockables
{
    public class Test_CryptoRandom
    {
        /// <summary>
        /// This test is just for coverage.
        /// </summary>
        [Fact]
        public void Ctor_ShouldBeOk()
        {
            FluentActions.Invoking(() => new CryptoRandom()).Should().NotThrow();
        }

        [Fact]
        public void NextBytes_ShouldCallRandomGenerator()
        {
            var buffer = new byte[2];
            var rng = A.Fake<RandomNumberGenerator>();

            A.CallTo(() => rng.GetBytes(buffer)).Invokes(c => {
                buffer[0] = 0x42;
                buffer[1] = 0x69;
            });

            CryptoRandom sut = new(rng);
            sut.NextBytes(buffer);
            buffer.Should().Equal(0x42, 0x69);
        }

        [Fact]
        public void Dispose_ShouldCallRandomNumberGenerator()
        {
            var rng = A.Fake<RandomNumberGenerator>();
            CryptoRandom sut = new(rng);
            sut.Dispose();
            A.CallTo(rng).Where(c => c.Method.Name == "Dispose").MustHaveHappened();
        }
    }
}
