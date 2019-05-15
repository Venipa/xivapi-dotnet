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
    [Route("api/character")]
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

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromQuery]string characterName, [FromQuery]string server)
        {
            if (Enum.TryParse(typeof(FFXIVServer), server, out var ffServer))
            {
                var searchResult = await _api.Character.GetCharacterByNameAsync(characterName, (FFXIVServer)ffServer);
                if (searchResult != null)
                {
                    return new JsonResult(searchResult);
                }
            }
            return new NotFoundObjectResult(characterName);
        }
    }
}
