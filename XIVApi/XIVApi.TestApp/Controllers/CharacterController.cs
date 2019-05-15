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
        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromQuery]string characterName, [FromQuery]string server)
        {
            var api = XIVApi.GetInstance(new Cache());
            if (Enum.TryParse(typeof(FFXIVServer), server, out var ffServer))
            {
                var searchResult = await api.Character.GetCharacterByNameAsync(characterName, (FFXIVServer)ffServer);
                if (searchResult != null)
                {
                    return new JsonResult(searchResult);
                }
            }
            return new NotFoundObjectResult(characterName);
        }
    }
}
