using System;
using System.Threading;
using System.Threading.Tasks;
using AuthClient.Models;
using AuthClient.Models.Requests;
using CrossUtility.Services;

namespace AuthClient.Services.Implementation;

public class CrossIdentityClient(IHttpService httpService) : IIdentityClient
{
    private const string WellKnownPath = "/.well-known/openid-configuration";
    
    public virtual Task<AuthorizationResponse> Authorize(AuthorizationRequest request)
    {
        throw new NotImplementedException($"{nameof(CrossIdentityClient)} doesn't support Authorization request");
    }

    public Task<TokenResponse> RequestToken(TokenRequest request, CancellationToken cancellationToken)
    {
        return httpService.PostFormAsync<TokenResponse, TokenRequest>(request.EndPoint, request, cancellationToken);
    }

    public Task<WellKnownEndpoint> RequestDocumentDiscovery(CancellationToken cancellationToken = default)
    {
        return httpService.GetAsync<WellKnownEndpoint>(WellKnownPath, cancellationToken);
    }
}
