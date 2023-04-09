using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Webinex.Tokens.Emails
{
    public static class TokensConfigurationExtensions
    {
        public static ITokensConfiguration AddEmails(
            this ITokensConfiguration configuration,
            string subjectKey,
            string bodyKey)
        {
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            subjectKey = subjectKey ?? throw new ArgumentNullException(nameof(subjectKey));
            bodyKey = bodyKey ?? throw new ArgumentNullException(nameof(bodyKey));

            return AddEmails(configuration, (_) => new TokenEmailTemplateKeys(subjectKey, bodyKey));
        }

        public static ITokensConfiguration AddEmails(
            [NotNull] this ITokensConfiguration configuration,
            [NotNull] Func<TokenSenderArgs<TokenEmailSenderArgs>, TokenEmailTemplateKeys> @delegate)
        {
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            @delegate = @delegate ?? throw new ArgumentNullException(nameof(@delegate));

            configuration.Services.AddSingleton<ITokenEmailKeysProvider>(
                new DelegateTemplateKeysProvider(@delegate));

            configuration.AddSender<TokenEmailSenderArgs, TokenEmailSender>();

            return configuration;
        }

        private class DelegateTemplateKeysProvider : ITokenEmailKeysProvider
        {
            private readonly Func<TokenSenderArgs<TokenEmailSenderArgs>, TokenEmailTemplateKeys> _delegate;

            public DelegateTemplateKeysProvider(
                Func<TokenSenderArgs<TokenEmailSenderArgs>, TokenEmailTemplateKeys> @delegate)
            {
                _delegate = @delegate;
            }

            public Task<TokenEmailTemplateKeys> GetAsync(TokenSenderArgs<TokenEmailSenderArgs> args)
            {
                return Task.FromResult(_delegate(args));
            }
        }
    }
}