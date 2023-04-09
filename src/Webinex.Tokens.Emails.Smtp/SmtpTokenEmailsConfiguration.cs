using System;

namespace Webinex.Tokens.Emails.Smtp
{
    internal class SmtpTokenEmailsConfiguration : ISmtpTokenEmailsConfiguration, ISmtpTokenEmailsSettings
    {
        public string FromName { get; private set; }
        public string FromEmail { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }
        public bool Ssl { get; private set; }
        public bool RequireAuth => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        public string Username { get; private set; }
        public string Password { get; private set; }

        public ISmtpTokenEmailsConfiguration UseSsl(bool withSsl)
        {
            Ssl = withSsl;
            return this;
        }

        public ISmtpTokenEmailsConfiguration UseHost(string host, int port)
        {
            Host = host ?? throw new ArgumentNullException(nameof(host));
            Port = port;
            return this;
        }

        public ISmtpTokenEmailsConfiguration UseCredentials(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            return this;
        }

        public ISmtpTokenEmailsConfiguration UseFrom(string name, string email)
        {
            FromName = name ?? throw new ArgumentNullException(nameof(name));
            FromEmail = email ?? throw new ArgumentNullException(nameof(email));
            return this;
        }

        public void Assert()
        {
            if (string.IsNullOrWhiteSpace(Host) || Port == default)
                throw new InvalidOperationException($"{nameof(UseHost)} might be called on smtp client configuration.");

            if (string.IsNullOrWhiteSpace(FromName) || string.IsNullOrWhiteSpace(FromEmail))
                throw new InvalidOperationException($"{nameof(UseFrom)} might be called on smtp client configuration.");
        }
    }
}