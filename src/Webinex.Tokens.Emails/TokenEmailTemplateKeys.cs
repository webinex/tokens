using System;

namespace Webinex.Tokens.Emails
{
    public class TokenEmailTemplateKeys
    {
        public TokenEmailTemplateKeys(string subject, string body)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string Subject { get; }
        
        public string Body { get; }
    }
}