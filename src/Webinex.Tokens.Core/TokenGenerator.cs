using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Webinex.Tokens
{
    internal interface ITokenGenerator
    {
        Task<string> GenerateAsync();
    }

    internal class TokenGenerator : ITokenGenerator
    {
        private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const int LENGTH = 22;

        
        public Task<string> GenerateAsync()
        {
            var result = new StringBuilder();
            using var rng = new RNGCryptoServiceProvider();
            byte[] uintBuffer = new byte[sizeof(uint)];

            for (int i = 0; i < LENGTH; i++)
            {
                rng.GetBytes(uintBuffer);
                uint num = BitConverter.ToUInt32(uintBuffer, 0);
                result.Append(CHARS[(int)(num % (uint)CHARS.Length)]);
            }

            return Task.FromResult(result.ToString());
        }
    }
}