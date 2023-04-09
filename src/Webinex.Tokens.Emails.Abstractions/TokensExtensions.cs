using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Webinex.Tokens.Emails
{
    public static class TokensExtensions
    {
        public static async Task SendEmailAsync(
            [NotNull] this ITokens tokens,
            [NotNull] TokenData tokenData,
            [NotNull] string recipientEmail)
        {
            tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
            tokenData = tokenData ?? throw new ArgumentNullException(nameof(tokenData));
            recipientEmail = recipientEmail ?? throw new ArgumentNullException(nameof(recipientEmail));

            await tokens.SendAsync(tokenData, new TokenEmailSenderArgs(recipientEmail));
        }
    }
}