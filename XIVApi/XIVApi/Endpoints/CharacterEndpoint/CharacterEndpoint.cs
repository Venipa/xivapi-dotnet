using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVApi.Caching;
using XIVApi.Endpoints.Interfaces;
using XIVApi.Http.Interfaces;
using XIVApi.Misc;

namespace XIVApi.Endpoints.CharacterEndpoint
{
    public class CharacterEndpoint : ICharacterEndpoint
    {
        private const string CharacterSearchUrl = "/character/search";
        private const string CharacterSearchCache = "charactersearch-{0}-{1}";
        private const string CharacterFetchUrl = "/character/{0}";
        private const string CharacterCache = "character-{0}-{1}";
        private const string CharacterVerificationUrl = "/character/{0}/verification";
        private const string CharacterRequestUpdateUrl = "/character/{0}/update";
        private static readonly TimeSpan CharacterTtl = TimeSpan.FromDays(7);

        private readonly IRequester _requester;
        private readonly ICache _cache;

        public CharacterEndpoint(IRequester requester, ICache cache)
        {
            _requester = requester ?? throw new ArgumentNullException(nameof(IRequester));
            _cache = cache ?? throw new ArgumentNullException(nameof(ICache));
        }

        public async Task<CharacterProfile> GetCharacterByIdAsync(string lodestoneId, bool extended)
        {
            var extendedResponse = extended ? 1 : 0;

            var characterProfileInCache = _cache.Get<string, CharacterProfile>(string.Format(CharacterCache, lodestoneId, extendedResponse));
            if (characterProfileInCache != null)
            {
                return characterProfileInCache;
            }

            var fetchUrl = string.Format(CharacterFetchUrl, lodestoneId);
            var jsonResponse = await _requester.CreateGetRequestAsync(
                fetchUrl, new List<string> { $"extended={extendedResponse}", $"data=AC,FR,FC,FCM,PVP" }).ConfigureAwait(false);

            var queryResult = JsonConvert.DeserializeObject<CharacterProfile>(jsonResponse);

            if (queryResult.Character != null)
            {
                _cache.Add(string.Format(CharacterCache, lodestoneId, extendedResponse), queryResult, CharacterTtl);
                return queryResult;
            }
            return null;
        }

        public async Task<CharacterSearch> GetCharacterByNameAsync(string characterName, FFXIVServer server)
        {
            var characterSearchInCache = _cache.Get<string, CharacterSearch>(string.Format(CharacterSearchCache, characterName, server));
            if (characterSearchInCache != null)
            {
                return characterSearchInCache;
            }
            var jsonResponse = await _requester.CreateGetRequestAsync(
                CharacterSearchUrl, new List<string> { $"name={characterName}", $"server={server}" }).ConfigureAwait(false);

            var queryResult = JsonConvert.DeserializeObject<QueryResult>(jsonResponse);

            if (queryResult.Characters?.Any() == true)
            {
                foreach (var character in queryResult.Characters)
                {
                    _cache.Add(string.Format(CharacterSearchCache, characterName, server), character, CharacterTtl);
                }
                return queryResult.Characters.FirstOrDefault();
            }
            return null;
        }

        public async Task<CharacterVerification> GetCharacterVerification(string lodestoneId)
        {
            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(CharacterVerificationUrl, lodestoneId)).ConfigureAwait(false);

            var queryResult = JsonConvert.DeserializeObject<CharacterVerification>(jsonResponse);
            return queryResult;
        }

        public async Task<bool> RequestCharacterUpdate(string lodestoneId)
        {
            var response = await _requester.CreateGetRequestAsync(
                string.Format(CharacterRequestUpdateUrl, lodestoneId)).ConfigureAwait(false);

            if (response != null)
            {
                return string.Equals(response, "1");
            }

            return false;
        }
    }
}
