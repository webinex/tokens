using System;
using Microsoft.Extensions.DependencyInjection;

namespace Webinex.Tokens.Emails.Smtp
{
    public static class SmtpEmailsTokenConfigurationExtensions
    {
        public static ITokensConfiguration AddSmtpEmailSender(
            this ITokensConfiguration tokensConfiguration,
            Action<ISmtpTokenEmailsConfiguration> configure)
        {
            tokensConfiguration = tokensConfiguration
                                      ?? throw new ArgumentNullException(nameof(tokensConfiguration));

            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            var services = tokensConfiguration.Services;
            var configuration = new SmtpTokenEmailsConfiguration();
            configure(configuration);
            configuration.Assert();

            services
                .AddSingleton<ISmtpTokenEmailsSettings>(configuration)
                .AddScoped<ITokenEmailSender, SmtpTokenEmailSender>();

            return tokensConfiguration;
        }
    }
}