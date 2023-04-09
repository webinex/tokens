using System;
using System.Diagnostics.CodeAnalysis;

namespace Webinex.Tokens
{
    public class TokenSenderArgs<TSenderArgs>
        where TSenderArgs : ITokenSenderArgs
    {
        public TokenSenderArgs(
            [NotNull] string token,
            [NotNull] TokenData tokenData,
            DateTime expireAtUtc,
            [NotNull] TSenderArgs senderArgs)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
            TokenData = tokenData ?? throw new ArgumentNullException(nameof(tokenData));
            ExpireAtUtc = expireAtUtc;
            SenderArgs = senderArgs ?? throw new ArgumentNullException(nameof(senderArgs));
        }

        [NotNull] public string Token { get; }

        [NotNull] public TokenData TokenData { get; }

        [NotNull] public DateTime ExpireAtUtc { get; }

        [NotNull] public TSenderArgs SenderArgs { get; }
    }
}