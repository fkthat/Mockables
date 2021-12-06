namespace FkThat.Mockables.Demo
{
    public class Test_Foo
    {
        [Fact]
        public void Bar_ShouldWriteData()
        {
            var clock = A.Fake<ISystemClock>();
            var guidGen = A.Fake<IGuidGen>();
            var random = A.Fake<IRandom>();
            var console = A.Fake<IConsole>();

            A.CallTo(() => clock.UtcNow).Returns(
                new DateTimeOffset(1973, 8, 9, 10, 17, 42, TimeSpan.Zero));

            A.CallTo(() => guidGen.NewGuid()).Returns(
                new Guid("{8AB11641-ACD5-490C-8587-B59B82C91C0D}"));

            A.CallTo(() => random.Next(16)).Returns(7);

            StringWriter writer = new();
            A.CallTo(() => console.Out).Returns(writer);

            Foo testee = new(clock, guidGen, random, console);
            testee.Bar();

            writer.ToString().Should().Be(
                "08/09/1973 10:17:42" + Environment.NewLine +
                "8ab11641-acd5-490c-8587-b59b82c91c0d" + Environment.NewLine +
                "7" + Environment.NewLine);
        }
    }
}
