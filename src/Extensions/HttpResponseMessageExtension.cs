using System.Linq;
using System.Net.Http;
using CrossUtility.Extensions;

namespace AuthClient.Extensions
{
    static class HttpResponseMessageExtension
    {
        public static void EnsureAcceptHeadersMatches(this HttpResponseMessage responseMessage)
        {
            var requestAcceptHeader = responseMessage.RequestMessage?.Headers.Accept;
            var responseContentType = responseMessage.Content?.Headers.ContentType;

            if (requestAcceptHeader.IsNullOrEmpty())
                return;

            foreach(var acceptHeader in requestAcceptHeader!)
            {
                if (acceptHeader.MediaType == responseContentType?.MediaType)
                    return;
            }

            responseMessage.Dispose();

            var expectedMediaTypes = string.Join(", ", requestAcceptHeader.Select(it => it.MediaType));
            throw new HttpRequestException(
                $"Unexpected Content-Type: '{responseContentType?.MediaType}', expecting: '{expectedMediaTypes}'"
            );
        }
    }
}
