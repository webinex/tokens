using System;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;

namespace Webinex.Tokens.Emails.Smtp
{
    internal class SmtpTokenEmailSender : ITokenEmailSender, IDisposable
    {
        private readonly ISmtpTokenEmailsSettings _settings;
        private readonly SmtpClientSender _smtpClientSender;

        public SmtpTokenEmailSender(ISmtpTokenEmailsSettings settings)
        {
            _settings = settings;
            _smtpClientSender = new SmtpClientSender(settings);
        }

        public async Task SendAsync(TokenEmail email)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            var message = NewMessage(email);
            await _smtpClientSender.SendAsync(message);
        }

        private MimeMessage NewMessage(TokenEmail email)
        {
            var message = new MimeMessage(
                new[] { new MailboxAddress(_settings.FromName, _settings.FromEmail) },
                new[] { new MailboxAddress(null, email.RecipientEmail) },
                email.Subject,
                new TextPart(TextFormat.Html)
                {
                    Text = email.Body,
                }
            );

            return message;
        }

        public void Dispose()
        {
            _smtpClientSender.Dispose();
        }

        private class SmtpClientSender : IDisposable
        {
            private readonly ISmtpTokenEmailsSettings _settings;
            private readonly MailKit.Net.Smtp.SmtpClient _client;

            public SmtpClientSender(ISmtpTokenEmailsSettings settings)
            {
                _settings = settings;
                _client = new MailKit.Net.Smtp.SmtpClient();
            }

            public async Task<string> SendAsync(MimeMessage message)
            {
                if (_client.IsConnected)
                {
                    return await _client.SendAsync(message);
                }

                await _client.ConnectAsync(_settings.Host, _settings.Port, _settings.Ssl);
                if (_settings.RequireAuth)
                {
                    await _client.AuthenticateAsync(_settings.Username, _settings.Password);
                }

                return await _client.SendAsync(message);
            }

            public void Dispose()
            {
                _client.Dispose();
            }
        }
    }
}