using System.Text.Json.Serialization;

namespace AuthClient.Services.Identity.Requests;

public class PasswordTokenRequest(
    string endPoint,
    string clientId,
    string? username,
    string? password,
    string? scope = null) : TokenRequest(endPoint, clientId, SupportedGrantType.Password, scope)
{
    [JsonPropertyName("username")]
    public string? Username { get; } = username;

    [JsonPropertyName("password")]
    public string? Password { get; } = password;
}
