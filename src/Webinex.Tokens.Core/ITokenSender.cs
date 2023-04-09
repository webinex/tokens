using System.Threading.Tasks;

namespace Webinex.Tokens
{
    public interface ITokenSender
    {
    }
    
    public interface ITokenSender<TArgs> : ITokenSender
        where TArgs : ITokenSenderArgs
    {
        Task SendAsync(TokenSenderArgs<TArgs> args);
    }
}