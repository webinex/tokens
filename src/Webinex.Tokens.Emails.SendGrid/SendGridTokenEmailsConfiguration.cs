using System;

namespace Webinex.Tokens.Emails.SendGrid
{
    internal class SendGridTokenEmailsConfiguration : ISendGridTokenEmailsSettings, ISendGridTokenEmailsConfiguration
    {
        public string Key { get; private set; }
        public string FromName { get; private set; }
        public string FromEmail { get; private set; }

        public ISendGridTokenEmailsConfiguration UseKey(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            return this;
        }

        public ISendGridTokenEmailsConfiguration UseFrom(string name, string email)
        {
            FromName = name ?? throw new ArgumentNullException(nameof(name));
            FromEmail = email ?? throw new ArgumentNullException(nameof(email));
            return this;
        }

        public void Assert()
        {
            if (string.IsNullOrWhiteSpace(Key))
                throw new InvalidOperationException($"{nameof(UseKey)} might be called on send grid configuration.");

            if (string.IsNullOrWhiteSpace(FromName) || string.IsNullOrWhiteSpace(FromEmail))
                throw new InvalidOperationException($"{nameof(UseFrom)} might be called on send grid configuration.");
        }
    }
}