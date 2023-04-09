using System;
using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens.Emails
{
    public class TokenEmail
    {
        public TokenEmail(string subject, string body, string recipientEmail)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            RecipientEmail = recipientEmail ?? throw new ArgumentNullException(nameof(recipientEmail));
        }
        
        [NotNull]
        public string RecipientEmail { get; }
        
        [NotNull]
        public string Subject { get; }
        
        [NotNull]
        public string Body { get; }
    }
}