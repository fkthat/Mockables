using System.Linq;
using FluentAssertions;
using Xunit;

namespace FkThat.Mockables
{
    public class Test_GuidGen
    {
        [Fact]
        public void NewGuid_ShouldReturnUniqueValues()
        {
            GuidGen sut = new();
            var r = Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid());
            r.Should().OnlyHaveUniqueItems();
        }
    }
}
