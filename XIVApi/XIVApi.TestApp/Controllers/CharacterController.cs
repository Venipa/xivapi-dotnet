using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XIVApi.Caching;
using XIVApi.Endpoints.CharacterEndpoint;
using XIVApi.Misc;

namespace XIVApi.TestApp.Controllers
{ 
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IXIVApi _api;
        private readonly ICache _cache;

        public CharacterController(IXIVApi xivApi, ICache cache)
        {
            _api = xivApi;
            _cache = cache;
        }

        [Route("api/character/search")]
        [HttpGet]
        public async Task<ActionResult<string>> SearchCharacterByName([FromQuery]string characterName, [FromQuery]string server)
        {
            if (Enum.TryParse(typeof(FFXIVServer), server, out var ffServer))
            {
                var searchResult = await _api.Character.GetCharacterByNameAsync(characterName, (FFXIVServer)ffServer).ConfigureAwait(false);
                if (searchResult != null)
                {
                    return new JsonResult(searchResult);
                }
            }
            return new NotFoundObjectResult(characterName);
        }

        [Route("api/character/profile")]
        [HttpGet()]
        public async Task<ActionResult<string>> GetCharacterById([FromQuery] string lodestoneId)
        {
            var characterResult = await _api.Character.GetCharacterByIdAsync(lodestoneId, true).ConfigureAwait(false);
            if (characterResult != null)
            {
                return new JsonResult(characterResult);
            }
            return new NotFoundObjectResult(lodestoneId);
        }

        [Route("api/character/verification")]
        [HttpGet()]
        public async Task<ActionResult<string>> GetCharacterVerification([FromQuery] string lodestoneId)
        {
            var verificationResult = await _api.Character.GetCharacterVerification(lodestoneId).ConfigureAwait(false);
            if (verificationResult != null)
            {
                return new JsonResult(verificationResult);
            }
            return new NotFoundObjectResult(lodestoneId);
        }
    }
}
