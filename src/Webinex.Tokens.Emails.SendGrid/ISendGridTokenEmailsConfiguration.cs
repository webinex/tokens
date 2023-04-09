using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens.Emails.SendGrid
{
    public interface ISendGridTokenEmailsConfiguration
    {
        ISendGridTokenEmailsConfiguration UseKey([NotNull] string key);
        ISendGridTokenEmailsConfiguration UseFrom([NotNull] string name, [NotNull] string email);
    }
}