using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens.Emails.SendGrid
{
    internal interface ISendGridTokenEmailsSettings
    {
        [NotNull] string Key { get; }
        [NotNull] string FromName { get; }
        [NotNull] string FromEmail { get; }
    }
}