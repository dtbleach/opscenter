using OpsPortal.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace OpsPortal.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly string authenticationScheme = "apikey";
        private readonly IHttpActionResult next;

        public ResultWithChallenge(IHttpActionResult next)
        {
            this.next = next;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await next.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(authenticationScheme));
            }

            return response;
        }
    }

    internal class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        public string ReasonPhrase { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            response.ReasonPhrase = ReasonPhrase;
            return response;
        }
    }

    public class ApiKeyAuthorizeAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return false; }
        }

        public ApiKeyAuthorizeAttribute()
        {
            if (string.IsNullOrEmpty(ApiKeyHeader))
            {
                ApiKeyHeader = Bootstrap.ServiceConfiguration.AuthUsername;
                ApiKey = Bootstrap.ServiceConfiguration.AuthPassword;
            }
        }

        // Hard code these for now, inject once it works.
        private static string ApiKeyHeader = "";
        private static string ApiKey = "";
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            IEnumerable<string> apiKeys;
            var hasHeader = request.Headers.TryGetValues(ApiKeyHeader, out apiKeys);
            if (!hasHeader || apiKeys.Count() == 0)
            {
                context.ErrorResult = new AuthenticationFailureResult("Authorization Missing", request);
                return;
            }

            if (apiKeys.First() != ApiKey)
            {
                context.ErrorResult = new AuthenticationFailureResult("Not Authorized", request);
                return;
            }

            var currentPrincipal = new GenericPrincipal(new GenericIdentity(apiKeys.First()), null);
            context.Principal = currentPrincipal;

            return;
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result);
            return Task.FromResult(0);
        }
    }
}