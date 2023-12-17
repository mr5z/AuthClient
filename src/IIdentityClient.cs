using AuthClient.Services.Identity;
using AuthClient.Services.Identity.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace AuthClient.Services;

public interface IIdentityClient
{
    Task<AuthorizationResponse> Authorize(AuthorizationRequest request);
    Task<TokenResponse> RequestToken(TokenRequest request, CancellationToken? cancellationToken = default);
}
