using System;
using System.Text.Json.Serialization;

namespace AuthClient.Models;

public record AuthorizationResponse(
    [property: JsonPropertyName("code")]
    string? Code,
    
    [property: JsonPropertyName("scope")]
    string? Scope,
    
    [property: JsonPropertyName("state")]
    Guid State,
    
    [property: JsonPropertyName("session_state")]
    string? SessionState
);
