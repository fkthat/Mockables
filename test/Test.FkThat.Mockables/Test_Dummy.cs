using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace FkThat.Mockables
{
    public class Test_Dummy
    {
        [Fact]
        public void Foo_ShouldReturnHello()
        {
            Dummy sut = new();
            sut.Foo().Should().Be("Hello");
        }
    }
}
