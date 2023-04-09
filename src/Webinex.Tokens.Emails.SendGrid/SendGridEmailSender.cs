using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Webinex.Tokens.Emails.SendGrid
{
    internal class SendGridEmailSender : ITokenEmailSender
    {
        private readonly ISendGridTokenEmailsSettings _settings;
        private readonly SendGridClient _sendGridClient;

        public SendGridEmailSender(
            ISendGridTokenEmailsSettings settings)
        {
            _settings = settings;
            _sendGridClient = new SendGridClient(settings.Key);
        }

        public async Task SendAsync(TokenEmail email)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            var message = NewMessage(email);
            var response = await _sendGridClient.SendEmailAsync(message);
            await ThrowIfFailedAsync(response);
        }

        private SendGridMessage NewMessage(TokenEmail email)
        {
            var message = MailHelper.CreateSingleEmail(
                new EmailAddress(_settings.FromEmail, _settings.FromName),
                new EmailAddress(email.RecipientEmail),
                email.Subject,
                null,
                email.Body);

            message.Headers = new Dictionary<string, string>
            {
                ["X-Priority"] = "1",
                ["Priority"] = "urgent",
                ["Importance"] = "high",
            };

            return message;
        }

        private async Task ThrowIfFailedAsync(Response response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var responseBodyString = await response.Body.ReadAsStringAsync();
            throw new InvalidOperationException($"Failed to send reset password link.{Environment.NewLine}" +
                                                $"StatusCode: {response.StatusCode}{Environment.NewLine}" +
                                                $"Body:{Environment.NewLine}{responseBodyString}");
        }
    }
}