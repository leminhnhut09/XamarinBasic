using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BlogApp.Services
{
    public class TransientExceptionHelper
    {
        private static readonly ISet<HttpStatusCode> TransientErrorStatusCodes = new HashSet<HttpStatusCode>(new[]
    {
        HttpStatusCode.BadGateway,
        HttpStatusCode.GatewayTimeout,
        HttpStatusCode.InternalServerError,
        HttpStatusCode.ServiceUnavailable,
        HttpStatusCode.RequestTimeout
    });
        public static bool IsTransient(Exception exception)
        {
            var apiException = exception as ApiException;
            if (apiException != null)
            {
                return TransientErrorStatusCodes.Contains(apiException.StatusCode);
            }
            return exception is HttpRequestException || exception is OperationCanceledException;
        }
    }
}
