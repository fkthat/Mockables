using FkThat.Mockables;
using FluentAssertions;
using Xunit;

namespace Microsoft.Extensions.DependencyInjection
{
    public class Test_ServiceCollectionExtensions
    {
        [Fact]
        public void AddMockables_ShouldAddRegistrations()
        {
            ServiceCollection services = new();
            var r = services.AddMockables();
            r.Should().BeSameAs(services);

            services.Should().BeEquivalentTo(
                new ServiceDescriptor(
                    typeof(ISystemClock), typeof(SystemClock), ServiceLifetime.Transient),
                new ServiceDescriptor(
                    typeof(IGuidGen), typeof(GuidGen), ServiceLifetime.Transient),
                new ServiceDescriptor(
                    typeof(IRandom), typeof(Random), ServiceLifetime.Transient));
        }
    }
}