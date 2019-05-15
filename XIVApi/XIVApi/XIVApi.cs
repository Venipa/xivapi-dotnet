using XIVApi.Caching;
using XIVApi.Endpoints.CharacterEndpoint;
using XIVApi.Endpoints.Interfaces;
using XIVApi.Http;

namespace XIVApi
{
    public class XIVApi : IXIVApi
    {
        private static XIVApi _instance;
        private string apiKey;
        private int rateLimit;

        public ICharacterEndpoint Character { get; }

        public XIVApi(ICache cache, string apiKey = "")
        {
            this.apiKey = apiKey;
            Requesters.XIVApiRequester = new Requester(apiKey);
            var requester = Requesters.XIVApiRequester;

            Character = new CharacterEndpoint(requester, cache);
        }

        public static XIVApi GetInstance(ICache cache = null, string apiKey = "")
        {
            if (_instance == null)
            {
                _instance = new XIVApi(cache ?? new PassThroughCache(), apiKey);
            }
            return _instance;
        }
    }
}