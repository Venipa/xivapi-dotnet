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
        private const string CharacterCache = "character-{0}-{1}";
        private static readonly TimeSpan CharacterTtl = TimeSpan.FromDays(7);

        private readonly IRequester _requester;
        private readonly ICache _cache;

        public CharacterEndpoint(IRequester requester, ICache cache)
        {
            _requester = requester ?? throw new ArgumentNullException(nameof(requester));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<Character> GetCharacterByNameAsync(string characterName, FFXIVServer server)
        {
            var characterInCache = _cache.Get<string, Character>(string.Format(CharacterCache, characterName, server));
            if (characterInCache != null)
            {
                return characterInCache;
            }
            var jsonResponse = await _requester.CreateGetRequestAsync(
                CharacterSearchUrl, new List<string> { $"name={characterName}", $"server={server}" });

            var queryResult = JsonConvert.DeserializeObject<QueryResult>(jsonResponse);

            if (queryResult.Characters != null && queryResult.Characters.Any())
            {
                foreach (var character in queryResult.Characters)
                {
                    _cache.Add(string.Format(CharacterCache, characterName, server), character, CharacterTtl);
                }
                return queryResult.Characters.FirstOrDefault();
            }
            return null;
        }
    }
}
