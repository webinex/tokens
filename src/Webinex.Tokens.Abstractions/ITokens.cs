using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Webinex.Tokens
{
    public interface ITokens
    {
        Task SendAsync<TSenderArgs>([NotNull] TokenData tokenData, TSenderArgs senderArgs)
            where TSenderArgs : ITokenSenderArgs;

        Task<string> AddAsync([NotNull] TokenData tokenData);

        Task<TokenValidationResult> ValidateAsync([NotNull] string tokenValue, [NotNull] string kind);

        Task RevokeUsedAsync([NotNull] string token);
    }
}