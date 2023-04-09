namespace Webinex.Tokens.Emails.Smtp
{
    internal interface ISmtpTokenEmailsSettings
    {
        public string FromName { get; }
        public string FromEmail { get; }
        public string Host { get; }
        public int Port { get; }
        public bool Ssl { get; }
        public bool RequireAuth { get; }
        public string Username { get; }
        public string Password { get; }
    }
}