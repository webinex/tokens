using System;
using Microsoft.Extensions.DependencyInjection;

namespace Webinex.Tokens.Emails.SendGrid
{
    public static class SendGridEmailsTokenConfigurationExtensions
    {
        public static ITokensConfiguration AddSendGridEmailSender(
            this ITokensConfiguration tokensConfiguration,
            Action<ISendGridTokenEmailsConfiguration> configure)
        {
            tokensConfiguration = tokensConfiguration
                                      ?? throw new ArgumentNullException(nameof(tokensConfiguration));

            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            var services = tokensConfiguration.Services;
            var configuration = new SendGridTokenEmailsConfiguration();
            configure(configuration);
            configuration.Assert();

            services.AddSingleton<ISendGridTokenEmailsSettings>(configuration);
            services.AddScoped<ITokenEmailSender, SendGridEmailSender>();

            return tokensConfiguration;
        }
    }
}