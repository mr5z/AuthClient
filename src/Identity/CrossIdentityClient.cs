using AuthClient.Extensions;
using AuthClient.Services.Identity.Requests;
using CrossUtility.Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AuthClient.Services.Identity;

public class CrossIdentityClient(HttpClient httpClient) : IIdentityClient
{
    private readonly HttpClient httpClient = httpClient;

    public virtual Task<AuthorizationResponse> Authorize(AuthorizationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<TokenResponse> RequestToken(TokenRequest request, CancellationToken? cancellationToken)
    {
        var serialized = JsonHelper.ToKeyValuePairs(request);
        var body = new FormUrlEncodedContent(serialized);
        var response = await httpClient.PostAsync(request.EndPoint, body, cancellationToken ?? CancellationToken.None);
        response.EnsureSuccessStatusCode();
        response.EnsureAcceptHeadersMatches();
        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return tokenResponse!;
    }
}
