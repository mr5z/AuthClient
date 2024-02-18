using System;
using System.Text.Json.Serialization;
using AuthClient.Enums;

namespace AuthClient.Models.Requests;

public class AuthorizationTokenRequest(
    Uri endPoint,
    string clientId,
    Uri redirectUri,
    Guid state,
    string codeVerifier,
    string? code,
    string[]? scopes = null) : TokenRequest(endPoint, clientId, SupportedGrantType.AuthorizationCode, scopes)
{
    [JsonPropertyName("redirect_uri")]
    public Uri RedirectUri { get; } = redirectUri;

    [JsonPropertyName("state")]
    public Guid State { get; } = state;

    [JsonPropertyName("code_verifier")]
    public string CodeVerifier { get; } = codeVerifier;

    [JsonPropertyName("code")]
    public string? Code { get; } = code;
}
