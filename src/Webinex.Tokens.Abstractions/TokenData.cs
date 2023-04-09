using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Webinex.Tokens
{
    public class TokenData
    {
        public TokenData(
            [NotNull] string kind,
            [MaybeNull] JsonObject payload,
            [MaybeNull] string userId,
            TimeSpan expireIn)
        {
            Kind = kind ?? throw new ArgumentNullException(nameof(kind));
            Payload = payload;
            UserId = userId;
            ExpireIn = expireIn;
        }

        public TokenData(
            [NotNull] string kind,
            [MaybeNull] object payload,
            [MaybeNull] string userId,
            TimeSpan expireIn)
            : this(
                kind,
                payload != null ? JsonObject.Create(JsonSerializer.SerializeToElement(payload)) : null,
                userId,
                expireIn)
        {
        }

        [MaybeNull] public JsonObject Payload { get; }

        [MaybeNull] public string UserId { get; }

        [NotNull] public string Kind { get; }

        public TimeSpan ExpireIn { get; }
    }
}