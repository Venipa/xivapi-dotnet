using Newtonsoft.Json;

namespace XIVApi.Endpoints.CharacterEndpoint
{
    public class CharacterVerification
    {
        [JsonProperty("ID")]
        public long ID { get; set; }

        [JsonProperty("Bio")]
        public string Bio { get; set; }

        [JsonProperty("Pass")]
        public bool Pass { get; set; }
    }
}