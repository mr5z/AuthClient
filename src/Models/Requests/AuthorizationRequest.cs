using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using AuthClient.Enums;
using CrossUtility.Helpers;
using static AuthClient.Models.CryptoHelper;

namespace AuthClient.Models.Requests;

public class AuthorizationRequest(
    Uri endPoint,
    Uri redirectUri,
    string clientId,
    ResponseType responseType,
    string[] scopes) : IdentityRequest(endPoint, clientId, string.Join(' ', scopes))
{
    private const int StandardMinCodeVerifierLength = 43;
    private const int StandardMaxCodeVerifierLength = 128;

    [JsonPropertyName("redirect_uri")]
    public Uri RedirectUri { get; } = redirectUri;

    [JsonPropertyName("response_type")]
    public ResponseType ResponseType { get; } = responseType;

    [JsonPropertyName("state")]
    public Guid State { get; } = Guid.NewGuid();

    [JsonPropertyName("code_challenge")]
    public string CodeChallenge => GenerateCodeChallenge();

    [JsonPropertyName("code_challenge_method")]
    public string CodeChallengeMethod => ChallengeMethod.ToString();

    [JsonIgnore]
    public string CodeVerifier { get; } = RandomString(StandardMinCodeVerifierLength, StandardMaxCodeVerifierLength);

    [JsonIgnore]
    public ChallengeMethod ChallengeMethod { get; init; }

    public Uri BuildUrl()
    {
        var queryString = QueryStringHelper.ToQueryString(this);
        var builder = new UriBuilder(EndPoint) { Query = queryString };
        return builder.Uri;
    }

    private string GenerateCodeChallenge()
    {
        return ChallengeMethod switch
        {
            ChallengeMethod.Plain => CodeVerifier,
            ChallengeMethod.S256 => ToSha256(CodeVerifier),
            _ => throw new InvalidEnumArgumentException(nameof(ChallengeMethod), (int)ChallengeMethod, typeof(ChallengeMethod))
        };
    }
}
