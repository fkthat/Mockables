namespace FkThat.Mockables
{
    public class Test_SystemGuidGen
    {
        [Fact]
        public void NewGuid_ShouldReturnUniqueValues()
        {
            SystemGuidGen sut = new();
            var r = Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid());
            r.Should().OnlyHaveUniqueItems();
        }
    }
}
