using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens.Emails.Smtp
{
    public interface ISmtpTokenEmailsConfiguration
    {
        ISmtpTokenEmailsConfiguration UseSsl(bool withSsl);
        ISmtpTokenEmailsConfiguration UseHost([NotNull] string host, int port);
        ISmtpTokenEmailsConfiguration UseFrom([NotNull] string name, [NotNull] string email);
        ISmtpTokenEmailsConfiguration UseCredentials([NotNull] string username, [NotNull] string password);
    }
}