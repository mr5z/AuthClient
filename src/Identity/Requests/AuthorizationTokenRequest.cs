using System;
using System.Text.Json.Serialization;

namespace AuthClient.Services.Identity.Requests;

public class AuthorizationTokenRequest(
    string endPoint,
    string clientId,
    string redirectUri,
    Guid state,
    string codeVerifier,
    string? code,
    string? scope = null) : TokenRequest(endPoint, clientId, SupportedGrantType.AuthorizationCode, scope)
{
    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; } = redirectUri;

    [JsonPropertyName("state")]
    public Guid State { get; } = state;

    [JsonPropertyName("code_verifier")]
    public string CodeVerifier { get; } = codeVerifier;

    [JsonPropertyName("code")]
    public string? Code { get; } = code;
}
