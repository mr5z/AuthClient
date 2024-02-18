using System;
using System.Text.Json.Serialization;

namespace AuthClient.Models;

public abstract class IdentityRequest(Uri endPoint, string clientId, string? scope = null)
{
    [JsonIgnore]
    public Uri EndPoint { get; } = endPoint;

    [JsonPropertyName("client_id")]
    public string ClientId { get; } = clientId;

    [JsonPropertyName("scope")]
    public string? Scope { get; } = scope;
}
