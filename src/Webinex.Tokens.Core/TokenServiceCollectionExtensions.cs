using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Webinex.Tokens
{
    public static class TokenServiceCollectionExtensions
    {
        public static IServiceCollection AddTokens<TToken>(
            [NotNull] this IServiceCollection services,
            [NotNull] Action<ITokensConfiguration> configure)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            var configuration = TokensConfiguration<TToken>.GetOrCreate(services);
            configure(configuration);
            return services;
        }
    }
}