using System.Text.Json.Serialization;

namespace AuthClient.Services.Identity;

public abstract class IdentityRequest(string endPoint, string clientId, string? scope = null)
{
    [JsonIgnore]
    public string EndPoint { get; } = endPoint;

    [JsonPropertyName("client_id")]
    public string ClientId { get; } = clientId;

    [JsonPropertyName("scope")]
    public string? Scope { get; } = scope;
}
