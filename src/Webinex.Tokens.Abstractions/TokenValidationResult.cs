using System;
using System.Text.Json.Nodes;

namespace Webinex.Tokens
{
    public class TokenValidationResult
    {
        private TokenValidationResult(
            string token,
            bool used = false,
            bool notFound = false,
            bool expired = false,
            bool wrongKind = false,
            string userId = null,
            JsonObject payload = null)
        {
            Used = used;
            NotFound = notFound;
            Expired = expired;
            WrongKind = wrongKind;
            UserId = userId;
            Payload = payload;
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public bool Valid => !Used && !NotFound && !Expired && !WrongKind;

        public bool Used { get; }

        public bool NotFound { get; }

        public bool Expired { get; }

        public bool WrongKind { get; }

        public string UserId { get; }

        public string Token { get; }
        
        public JsonObject Payload { get; }

        public string Error =>
            Used ? "Used" : NotFound ? "NotFound" : Expired ? "Expired" : WrongKind ? "WrongKind" : null;

        public static TokenValidationResult NewUsed(string token) => new TokenValidationResult(token, used: true);

        public static TokenValidationResult NewNotFound(string token) =>
            new TokenValidationResult(token, notFound: true);

        public static TokenValidationResult NewExpired(string token) => new TokenValidationResult(token, expired: true);

        public static TokenValidationResult NewWrongKind(string token) =>
            new TokenValidationResult(token, wrongKind: true);

        public static TokenValidationResult NewSucceed(string token, string userId, JsonObject payload) =>
            new TokenValidationResult(token, userId: userId, payload: payload);
    }
}