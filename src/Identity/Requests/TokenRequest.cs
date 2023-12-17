using System;
using System.Text.Json.Serialization;

namespace AuthClient.Services.Identity.Requests;

public abstract class TokenRequest(
    string endPoint,
    string clientId,
    SupportedGrantType requestedGrantType,
    string? scope = null) : IdentityRequest(endPoint, clientId, scope)
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
