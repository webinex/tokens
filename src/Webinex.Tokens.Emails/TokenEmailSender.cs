using System.Threading.Tasks;
using Webinex.Temply;

namespace Webinex.Tokens.Emails
{
    internal class TokenEmailSender : ITokenSender<TokenEmailSenderArgs>
    {
        private readonly ITemply _temply;
        private readonly ITokenEmailKeysProvider _emailKeysProvider;
        private readonly ITokenEmailSender _emailSender;

        public TokenEmailSender(
            ITemply temply,
            ITokenEmailKeysProvider emailKeysProvider,
            ITokenEmailSender emailSender)
        {
            _temply = temply;
            _emailKeysProvider = emailKeysProvider;
            _emailSender = emailSender;
        }

        public async Task SendAsync(TokenSenderArgs<TokenEmailSenderArgs> args)
        {
            var email = await GenerateAsync(args);
            await _emailSender.SendAsync(email);
        }

        private async Task<TokenEmail> GenerateAsync(TokenSenderArgs<TokenEmailSenderArgs> args)
        {
            var data = new
            {
                args.Token,
                args.ExpireAtUtc,
                args.SenderArgs,
                args.TokenData.Kind,
                args.TokenData.Payload
            };
            
            var keys = await _emailKeysProvider.GetAsync(args);
            var subject = await _temply.RenderAsync(new TemplyArgs(keys.Subject, data));
            var body = await _temply.RenderAsync(new TemplyArgs(keys.Body, data));
            return new TokenEmail(subject, body, args.SenderArgs.RecipientEmail);
        }
    }
}