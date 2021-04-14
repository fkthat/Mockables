using FkThat.Tdd;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Mockables extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the mockables.
        /// </summary>
        /// <param name="services">The <c cref="IServiceCollection"/> instance.</param>
        /// <returns>The <c cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTdd(this IServiceCollection services) =>
            services.AddTransient<ISystemClock, SystemClock>()
                .AddTransient<IGuidGen, GuidGen>()
                .AddTransient<IRandom, Random>();
    }
}
