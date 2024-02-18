using System;
using System.Text.Json.Serialization;
using AuthClient.Enums;

namespace AuthClient.Models.Requests;

public class PasswordTokenRequest(
    Uri endPoint,
    string clientId,
    string? username,
    string? password,
    string[]? scopes = null) : TokenRequest(endPoint, clientId, SupportedGrantType.Password, scopes)
{
    [JsonPropertyName("username")]
    public string? Username { get; } = username;

    [JsonPropertyName("password")]
    public string? Password { get; } = password;
}
