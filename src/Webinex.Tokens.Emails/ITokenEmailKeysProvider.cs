using System.Threading.Tasks;

namespace Webinex.Tokens.Emails
{
    public interface ITokenEmailKeysProvider
    {
        Task<TokenEmailTemplateKeys> GetAsync(TokenSenderArgs<TokenEmailSenderArgs> args);
    }
}