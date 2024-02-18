using System;
using System.Text.Json.Serialization;
using AuthClient.Enums;

namespace AuthClient.Models.Requests;

public abstract class TokenRequest(
    Uri endPoint,
    string clientId,
    SupportedGrantType requestedGrantType,
    string[]? scopes = null) : IdentityRequest(endPoint, clientId, string.Join(' ', scopes))
{
    [JsonPropertyName("grant_type")]
    public string GrantType => RequestedGrantType switch
    {
        SupportedGrantType.AuthorizationCode => "authorization_code",
        SupportedGrantType.Password => "password",
        _ => throw new NotSupportedException(nameof(GrantType))
    };

    [JsonIgnore]
    public SupportedGrantType RequestedGrantType { get; } = requestedGrantType;
}
