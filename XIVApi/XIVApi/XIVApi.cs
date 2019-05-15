using System;
using XIVApi.Caching;
using XIVApi.Endpoints.CharacterEndpoint;
using XIVApi.Endpoints.Interfaces;
using XIVApi.Http;
using XIVApi.Http.Interfaces;

namespace XIVApi
{
    public class XIVApi : IXIVApi
    {
        private static XIVApi _instance;
        private readonly ICache _cache;

        public ICharacterEndpoint Character { get; }

        public XIVApi(ICache cache, string apiKey = "")
        {
            Requesters.XIVApiRequester = new Requester(apiKey);
            var requester = Requesters.XIVApiRequester;

            Character = new CharacterEndpoint(requester, cache);
        }

        public XIVApi(IRequester requester, ICache cache = null)
        {
            if (requester == null)
            {
                throw new ArgumentNullException(nameof(requester));
            }

            _cache = cache ?? new PassThroughCache();
            Character = new CharacterEndpoint(requester, _cache);
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