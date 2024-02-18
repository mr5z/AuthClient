using System;
using System.Text.Json.Serialization;

namespace AuthClient.Models;

public record WellKnownEndpoint(
    [property: JsonPropertyName("authorization_endpoint")]
    Uri AuthorizationEndpoint,
    
    [property: JsonPropertyName("token_endpoint")]
    Uri TokenEndpoint
);
