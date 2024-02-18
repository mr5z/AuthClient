using System;
using System.Net.Http;
using System.Net.Http.Headers;
using AuthClient.Models;

namespace AuthClient.Extensions;

public static class HttpClientExtension
{
    public static void Authorize(this HttpClient httpClient, TokenResponse tokenResponse)
    {
        var headers = httpClient.DefaultRequestHeaders;
        var scheme = tokenResponse.TokenType ?? throw new InvalidOperationException($"'{nameof(TokenResponse)}.scheme' must not be null.");
        var parameter = tokenResponse.AccessToken;
        headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
    }
}