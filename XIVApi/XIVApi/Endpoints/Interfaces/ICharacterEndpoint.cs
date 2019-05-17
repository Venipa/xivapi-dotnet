using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVApi.Endpoints.CharacterEndpoint;
using XIVApi.Misc;

namespace XIVApi.Endpoints.Interfaces
{
    public interface ICharacterEndpoint
    {
        Task<CharacterSearch> GetCharacterByNameAsync(string characterName, FFXIVServer server);

        Task<CharacterProfile> GetCharacterByIdAsync(string lodestoneId, bool extended);

        Task<CharacterVerification> GetCharacterVerification(string lodestoneId);

        Task<bool> RequestCharacterUpdate(string lodestoneId);
    }
}
