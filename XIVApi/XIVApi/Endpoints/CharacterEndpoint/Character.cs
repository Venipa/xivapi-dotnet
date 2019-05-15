using System;
using System.Collections.Generic;
using System.Text;
using XIVApi.Misc;

namespace XIVApi.Endpoints.CharacterEndpoint
{
    public class Character
    {
        public string Avatar { get; set; }
        public int FeastMatches { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string RankIcon { get; set; }
        public FFXIVServer Server { get; set; }
    }
}
