using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVApi.Endpoints.CharacterEndpoint
{
    public class QueryResult
    {
        [JsonProperty("Results")]
        public List<Character> Characters { get; set; }
    }
}
