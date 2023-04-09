using System;
using System.Threading.Tasks;

namespace Webinex.Tokens
{
    internal class Tokens<TToken> : ITokens
    {
        private readonly ITokenGenerator _generator;
        private readonly ITokenStore<TToken> _store;
        private readonly ITokenSenderOrchestrator _senderOrchestrator;

        public Tokens(
            ITokenGenerator generator,
            ITokenStore<TToken> store,
            ITokenSenderOrchestrator senderOrchestrator)
        {
            _generator = generator;
            _store = store;
            _senderOrchestrator = senderOrchestrator;
        }

        public async Task SendAsync<TSenderArgs>(TokenData tokenData, TSenderArgs senderArgs)
            where TSenderArgs : ITokenSenderArgs
        {
            tokenData = tokenData ?? throw new ArgumentNullException(nameof(tokenData));
            senderArgs = senderArgs ?? throw new ArgumentNullException(nameof(senderArgs));
            var (tokenValue, expireAtUtc) = await AddInternalAsync(tokenData);
            await _senderOrchestrator.SendAsync(tokenData, senderArgs, tokenValue, expireAtUtc);
        }

        public async Task<string> AddAsync(TokenData tokenData)
        {
            tokenData = tokenData ?? throw new ArgumentNullException(nameof(tokenData));
            var (tokenValue, _) = await AddInternalAsync(tokenData);
            return tokenValue;
        }

        private async Task<(string tokenValue, DateTime expireAtUtc)> AddInternalAsync(TokenData tokenData)
        {
            var tokenValue = await _generator.GenerateAsync();
            var expireAtUtc = GetExpireAtUtc(tokenData);
            await _store.AddAsync(tokenData, tokenValue, expireAtUtc);
            return (tokenValue, expireAtUtc);
        }

        private DateTime GetExpireAtUtc(TokenData tokenData)
        {
            return DateTime.UtcNow.Add(tokenData.ExpireIn);
        }

        public async Task<TokenValidationResult> ValidateAsync(string tokenValue, string kind)
        {
            tokenValue = tokenValue ?? throw new ArgumentNullException(nameof(tokenValue));
            kind = kind ?? throw new ArgumentNullException(nameof(kind));
            var token = await _store.GetAsync(tokenValue);

            if (token == null)
                return TokenValidationResult.NewNotFound(tokenValue);
            
            if (await _store.Kind(token) != kind)
                return TokenValidationResult.NewWrongKind(tokenValue);

            if (await _store.Used(token))
                return TokenValidationResult.NewUsed(tokenValue);

            if (await _store.ExpireAt(token) < DateTime.UtcNow)
                return TokenValidationResult.NewExpired(tokenValue);

            var userId = await _store.UserId(token);
            var payload = await _store.Payload(token);
            return TokenValidationResult.NewSucceed(tokenValue, userId, payload);
        }

        public async Task RevokeUsedAsync(string tokenString)
        {
            tokenString = tokenString ?? throw new ArgumentNullException(nameof(tokenString));
            var token = await _store.GetAsync(tokenString);
            await _store.MarkUsedAsync(token);
        }
    }
}