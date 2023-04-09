using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Webinex.Tokens
{
    public interface ITokensConfiguration
    {
        IServiceCollection Services { get; }
        Type TokenType { get; }
        ITokensConfiguration AddStore(Type type);
        IDictionary<string, object> Values { get; }
    }

    internal class TokensConfiguration<TToken> : ITokensConfiguration
    {
        private TokensConfiguration(IServiceCollection services)
        {
            Services = services;

            services.TryAddSingleton<ITokenGenerator, TokenGenerator>();
            services.TryAddScoped<ITokens, Tokens<TToken>>();
            services.TryAddScoped<ITokenSenderOrchestrator, TokenSenderOrchestrator>();
        }

        public IServiceCollection Services { get; }

        public Type TokenType => typeof(TToken);

        public IDictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public ITokensConfiguration AddStore(Type type)
        {
            if (!type.IsAssignableTo(typeof(ITokenStore<TToken>)))
                throw new InvalidOperationException(
                    $"Type {type.Name} might be assignable to {typeof(ITokenStore<TToken>).Name}");

            Services.Add(new ServiceDescriptor(typeof(ITokenStore<TToken>), type, ServiceLifetime.Scoped));
            return this;
        }

        public static TokensConfiguration<TToken> GetOrCreate(
            IServiceCollection services)
        {
            var instance = (TokensConfiguration<TToken>)services.SingleOrDefault(x =>
                    x.Lifetime == ServiceLifetime.Singleton &&
                    x.ServiceType == typeof(TokensConfiguration<TToken>))
                ?.ImplementationInstance;

            if (instance != null)
                return instance;

            instance = new TokensConfiguration<TToken>(services);
            services.AddSingleton(instance);
            return instance;
        }
    }

    public static class TokensConfigurationExtensions
    {
        public static ITokensConfiguration AddStore<T>(
            [NotNull] this ITokensConfiguration configuration)
        {
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            return configuration.AddStore(typeof(T));
        }

        public static ITokensConfiguration AddSender<TArgs, TSender>(
            [NotNull] this ITokensConfiguration configuration)
            where TArgs : ITokenSenderArgs
            where TSender : class, ITokenSender<TArgs>
        {
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            configuration.Services.TryAddScoped<TSender>();
            configuration.Services.AddScoped<ITokenSender>(x => x.GetRequiredService<TSender>());
            configuration.Services.AddScoped<ITokenSender<TArgs>>(x => x.GetRequiredService<TSender>());
            return configuration;
        }
    }
}