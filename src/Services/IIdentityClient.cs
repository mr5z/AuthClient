using System.Threading;
using System.Threading.Tasks;
using AuthClient.Models;
using AuthClient.Models.Requests;

namespace AuthClient.Services;

public interface IIdentityClient
{
    Task<AuthorizationResponse> Authorize(AuthorizationRequest request);
    Task<TokenResponse> RequestToken(TokenRequest request, CancellationToken cancellationToken = default);
    Task<WellKnownEndpoint> RequestDocumentDiscovery(CancellationToken cancellationToken = default);
}
