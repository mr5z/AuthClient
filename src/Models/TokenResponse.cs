using System.Text.Json.Serialization;

namespace AuthClient.Models;

public record TokenResponse(
    [property: JsonPropertyName("id_token")]
    string? IdToken,
    [property: JsonPropertyName("access_token")]
    string? AccessToken,
    [property: JsonPropertyName("expires_in")]
    int ExpiresIn,
    [property: JsonPropertyName("token_type")]
    string? TokenType,
    [property: JsonPropertyName("scope")]
    string? Scope
);