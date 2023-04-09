using System;
using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens.Emails
{
    public class TokenEmailSenderArgs : ITokenSenderArgs
    {
        public TokenEmailSenderArgs(
            [NotNull] string recipientEmail)
        {
            RecipientEmail = recipientEmail ?? throw new ArgumentNullException(nameof(recipientEmail));
        }

        [NotNull]
        public string RecipientEmail { get; }
    }
}