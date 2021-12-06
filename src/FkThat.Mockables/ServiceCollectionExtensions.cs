using FkThat.Mockables;
using Random = FkThat.Mockables.Random;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods to <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Tdd classes.
        /// </summary>
        /// <param name="services">The <c cref="IServiceCollection"/> instance.</param>
        /// <returns>The <c cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMockables(this IServiceCollection services) =>
            services.AddTransient<ISystemClock, SystemClock>()
                .AddTransient<IGuidGen, GuidGen>()
                .AddTransient<IRandom, Random>()
                .AddTransient<IConsole, ConsoleAdapter>();
    }
}
