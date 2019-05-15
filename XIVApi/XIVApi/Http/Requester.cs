using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XIVApi.Http.Interfaces;
using XIVApi.Misc;

namespace XIVApi.Http
{
    public class Requester : RequesterBase, IRequester
    {

        private RateLimiter _rateLimiter = null;

        public Requester(string apiKey) : base(apiKey)
        {
        }

        public Requester()
        { }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, List<string> queryParameters = null)
        {
            var request = PrepareRequest(relativeUrl, queryParameters, HttpMethod.Get);
            return await GetRateLimitedResponseContentAsync(request).ConfigureAwait(false);
        }

        private async Task<string> GetRateLimitedResponseContentAsync(HttpRequestMessage request)
        {
            await GetRateLimiter().HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await SendAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }

        private RateLimiter GetRateLimiter()
        {
            if (_rateLimiter == null)
            {
                _rateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
                {
                    [TimeSpan.FromSeconds(1)] = string.IsNullOrWhiteSpace(ApiKey) ? 15 : 30
                });
            }

            return _rateLimiter;
        }
    }
}