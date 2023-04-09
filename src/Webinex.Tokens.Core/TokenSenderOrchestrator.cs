using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Webinex.Tokens
{
    internal interface ITokenSenderOrchestrator
    {
        Task SendAsync<TSenderArgs>(
            [NotNull] TokenData tokenData,
            [NotNull] TSenderArgs senderArgs,
            [NotNull] string tokenValue,
            DateTime expireAtUtc
        )
            where TSenderArgs : ITokenSenderArgs;
    }

    internal class TokenSenderOrchestrator : ITokenSenderOrchestrator
    {
        private readonly IEnumerable<ITokenSender> _senders;

        public TokenSenderOrchestrator(IEnumerable<ITokenSender> senders)
        {
            _senders = senders;
        }

        public async Task SendAsync<TSenderArgs>(
            TokenData tokenData,
            TSenderArgs senderArgs,
            string tokenValue,
            DateTime expireAtUtc)
            where TSenderArgs : ITokenSenderArgs
        {
            tokenData = tokenData ?? throw new ArgumentNullException(nameof(tokenData));
            tokenValue = tokenValue ?? throw new ArgumentNullException(nameof(tokenValue));
            senderArgs = senderArgs ?? throw new ArgumentNullException(nameof(senderArgs));

            var tokenSenderArgs = new TokenSenderArgs<TSenderArgs>(
                tokenValue, tokenData, expireAtUtc, senderArgs);
            var sender = FindSender<TSenderArgs>();
            await sender.SendAsync(tokenSenderArgs);
        }

        private ITokenSender<TSenderArgs> FindSender<TSenderArgs>()
            where TSenderArgs : ITokenSenderArgs
        {
            var expectedType = typeof(ITokenSender<TSenderArgs>);
            var sender = (ITokenSender<TSenderArgs>)_senders.FirstOrDefault(sender =>
                sender.GetType().GetInterfaces().Any(interfaceType => interfaceType == expectedType));
            return sender ?? throw new InvalidOperationException($"Sender of type {expectedType.Name} not found");
        }
    }
}