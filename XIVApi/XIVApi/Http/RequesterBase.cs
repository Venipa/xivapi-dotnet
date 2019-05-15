using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace XIVApi.Http
{
    public abstract class RequesterBase
    {
        protected const string BaseDomain = "https://xivapi.com";
        private readonly HttpClient _httpClient;

        public string ApiKey { get; set; }

        protected RequesterBase(string apiKey) : this()
        {
            ApiKey = apiKey;
        }

        protected RequesterBase()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response);
            }
            return response;
        }

        protected HttpRequestMessage PrepareRequest(string relativeUrl, List<string> queryParameters, HttpMethod httpMethod)
        {
            var url = queryParameters == null ?
                $"{BaseDomain}{relativeUrl}" :
                $"{BaseDomain}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

            if (!string.IsNullOrEmpty(ApiKey))
            {
                url += $"&private_key={ApiKey}";
            }

            var requestMessage = new HttpRequestMessage(httpMethod, url);
            return requestMessage;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
        }

        protected void HandleRequestFailure(HttpResponseMessage response)
        {
            var statusCode = response.StatusCode;
            try
            {
                switch (statusCode)
                {
                    case HttpStatusCode.ServiceUnavailable:
                        throw new XIVException("503, Service unavailable", statusCode);
                    case HttpStatusCode.InternalServerError:
                        throw new XIVException("500, Internal server error", statusCode);
                    case HttpStatusCode.Unauthorized:
                        throw new XIVException("401, Unauthorized", statusCode);
                    case HttpStatusCode.BadRequest:
                        throw new XIVException("400, Bad request", statusCode);
                    case HttpStatusCode.NotFound:
                        throw new XIVException("404, Resource not found", statusCode);
                    case HttpStatusCode.Forbidden:
                        throw new XIVException("403, Forbidden", statusCode);
                    case (HttpStatusCode)429:
                        throw new XIVException("429, Rate Limit Exceeded", statusCode);
                    default:
                        throw new XIVException("Unexpeced failure", statusCode);
                }
            }
            finally
            {
                response.Dispose();
            }
        }

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}