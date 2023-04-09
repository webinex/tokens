using System.Threading.Tasks;

namespace Webinex.Tokens.Emails
{
    public interface ITokenEmailSender
    {
        Task SendAsync(TokenEmail email);
    }
}