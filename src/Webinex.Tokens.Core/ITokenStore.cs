using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Webinex.Tokens
{
    public interface ITokenStore<TToken>
    {
        Task<TToken> GetAsync(string value);

        Task<TToken> AddAsync(TokenData tokenData, string tokenValue, DateTime expireAtUtc);

        Task<DateTime> ExpireAt(TToken token);

        Task<bool> Used(TToken token);

        Task<string> UserId(TToken token);

        Task<JsonObject> Payload(TToken token);

        Task<string> Kind(TToken token);

        Task MarkUsedAsync(TToken token);
    }
}