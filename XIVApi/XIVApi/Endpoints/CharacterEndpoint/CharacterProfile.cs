using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using XIVApi.Misc;

namespace XIVApi.Endpoints.CharacterEndpoint
{
    public class CharacterProfile
    {
        [JsonProperty("Achievements")]
        public Achievements Achievements { get; set; }

        [JsonProperty("Character")]
        public Character Character { get; set; }

        [JsonProperty("FreeCompany")]
        public FreeCompany FreeCompany { get; set; }

        [JsonProperty("FreeCompanyMembers")]
        public List<FreeCompanyMember> FreeCompanyMembers { get; set; }

        [JsonProperty("Friends")]
        public object Friends { get; set; }

        [JsonProperty("Info")]
        public Info Info { get; set; }

        [JsonProperty("PvPTeam")]
        public object PvPTeam { get; set; }
    }

    public class Achievements
    {
        [JsonProperty("List")]
        public List<List> List { get; set; }

        [JsonProperty("ParseDate")]
        public long ParseDate { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public class List
    {
        [JsonProperty("Date")]
        public long Date { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public class Character
    {
        [JsonProperty("ActiveClassJob")]
        public ClassJob ActiveClassJob { get; set; }

        [JsonProperty("Avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("Bio")]
        public string Bio { get; set; }

        [JsonProperty("ClassJobs")]
        public Dictionary<string, ClassJob> ClassJobs { get; set; }

        [JsonProperty("FreeCompanyId")]
        public string FreeCompanyId { get; set; }

        [JsonProperty("GearSet")]
        public GearSet GearSet { get; set; }

        [JsonProperty("Gender")]
        public long Gender { get; set; }

        [JsonProperty("GenderID")]
        public long GenderId { get; set; }

        [JsonProperty("GrandCompany")]
        public GrandCompany GrandCompany { get; set; }

        [JsonProperty("GuardianDeity")]
        public InfoObject GuardianDeity { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Minions")]
        public List<InfoObject> Minions { get; set; }

        [JsonProperty("MinionsCount")]
        public long MinionsCount { get; set; }

        [JsonProperty("MinionsProgress")]
        public string MinionsProgress { get; set; }

        [JsonProperty("MinionsTotal")]
        public long MinionsTotal { get; set; }

        [JsonProperty("Mounts")]
        public List<InfoObject> Mounts { get; set; }

        [JsonProperty("MountsCount")]
        public long MountsCount { get; set; }

        [JsonProperty("MountsProgress")]
        public string MountsProgress { get; set; }

        [JsonProperty("MountsTotal")]
        public long MountsTotal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Nameday")]
        public string Nameday { get; set; }

        [JsonProperty("ParseDate")]
        public long ParseDate { get; set; }

        [JsonProperty("Portrait")]
        public Uri Portrait { get; set; }

        [JsonProperty("PvPTeamId")]
        public object PvPTeamId { get; set; }

        [JsonProperty("Race")]
        public InfoObject Race { get; set; }

        [JsonProperty("Server")]
        public FFXIVServer Server { get; set; }

        [JsonProperty("Title")]
        public InfoObject Title { get; set; }

        [JsonProperty("Town")]
        public InfoObject Town { get; set; }

        [JsonProperty("Tribe")]
        public InfoObject Tribe { get; set; }
    }

    public class ClassJob
    {
        [JsonProperty("Class")]
        public Class Class { get; set; }

        [JsonProperty("ExpLevel")]
        public long ExpLevel { get; set; }

        [JsonProperty("ExpLevelMax")]
        public long ExpLevelMax { get; set; }

        [JsonProperty("ExpLevelTogo")]
        public long ExpLevelTogo { get; set; }

        [JsonProperty("IsSpecialised")]
        public bool IsSpecialised { get; set; }

        [JsonProperty("Job")]
        public Class Job { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }
    }

    public class Class
    {
        [JsonProperty("Abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("ClassJobCategory", NullValueHandling = NullValueHandling.Ignore)]
        public BasicObject ClassJobCategory { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }
    }

    public class BasicObject
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class GearSet
    {
        [JsonProperty("Attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("Class")]
        public Class Class { get; set; }

        [JsonProperty("Gear")]
        public Dictionary<string, Gear> Gear { get; set; }

        [JsonProperty("GearKey")]
        public string GearKey { get; set; }

        [JsonProperty("Job")]
        public Class Job { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("Attribute")]
        public BasicObject ChildAttribute { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }
    }

    public class Gear
    {
        [JsonProperty("Creator")]
        public long? Creator { get; set; }

        [JsonProperty("Dye")]
        public Dye Dye { get; set; }

        [JsonProperty("Item")]
        public Item Item { get; set; }

        [JsonProperty("Materia")]
        public List<object> Materia { get; set; }

        [JsonProperty("Mirage")]
        public object Mirage { get; set; }
    }

    public class Dye
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Item
    {
        [JsonProperty("ClassJobCategory")]
        public BasicObject ClassJobCategory { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("ItemUICategory")]
        public BasicObject ItemUiCategory { get; set; }

        [JsonProperty("LevelEquip")]
        public long LevelEquip { get; set; }

        [JsonProperty("LevelItem")]
        public long LevelItem { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Rarity")]
        public long Rarity { get; set; }
    }

    public class GrandCompany
    {
        [JsonProperty("Company")]
        public InfoObject Company { get; set; }

        [JsonProperty("Rank")]
        public InfoObject Rank { get; set; }
    }

    public class InfoObject
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("IconSmall", NullValueHandling = NullValueHandling.Ignore)]
        public string IconSmall { get; set; }
    }

    public class FreeCompany
    {
        [JsonProperty("Active")]
        public string Active { get; set; }

        [JsonProperty("ActiveMemberCount")]
        public long ActiveMemberCount { get; set; }

        [JsonProperty("Crest")]
        public List<Uri> Crest { get; set; }

        [JsonProperty("Estate")]
        public Estate Estate { get; set; }

        [JsonProperty("Focus")]
        public List<Focus> Focus { get; set; }

        [JsonProperty("Formed")]
        public long Formed { get; set; }

        [JsonProperty("GrandCompany")]
        public string GrandCompany { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ParseDate")]
        public long ParseDate { get; set; }

        [JsonProperty("Rank")]
        public long Rank { get; set; }

        [JsonProperty("Ranking")]
        public Ranking Ranking { get; set; }

        [JsonProperty("Recruitment")]
        public string Recruitment { get; set; }

        [JsonProperty("Reputation")]
        public List<Reputation> Reputation { get; set; }

        [JsonProperty("Seeking")]
        public List<Focus> Seeking { get; set; }

        [JsonProperty("Server")]
        public FFXIVServer Server { get; set; }

        [JsonProperty("Slogan")]
        public string Slogan { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }
    }

    public class Estate
    {
        [JsonProperty("Greeting")]
        public string Greeting { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }
    }

    public class Focus
    {
        [JsonProperty("Icon")]
        public Uri Icon { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }
    }

    public class Ranking
    {
        [JsonProperty("Monthly")]
        public string Monthly { get; set; }

        [JsonProperty("Weekly")]
        public string Weekly { get; set; }
    }

    public class Reputation
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Progress")]
        public long Progress { get; set; }

        [JsonProperty("Rank")]
        public string Rank { get; set; }
    }

    public class FreeCompanyMember
    {
        [JsonProperty("Avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("FeastMatches")]
        public long FeastMatches { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Rank")]
        public string Rank { get; set; }

        [JsonProperty("RankIcon")]
        public Uri RankIcon { get; set; }

        [JsonProperty("Server")]
        public FFXIVServer Server { get; set; }
    }

    public class Info
    {
        [JsonProperty("Achievements")]
        public CharacterClass Achievements { get; set; }

        [JsonProperty("Character")]
        public CharacterClass Character { get; set; }

        [JsonProperty("FreeCompany")]
        public CharacterClass FreeCompany { get; set; }

        [JsonProperty("FreeCompanyMembers")]
        public CharacterClass FreeCompanyMembers { get; set; }

        [JsonProperty("Friends")]
        public CharacterClass Friends { get; set; }

        [JsonProperty("PvPTeam")]
        public object PvPTeam { get; set; }
    }

    public class CharacterClass
    {
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Priority")]
        public long Priority { get; set; }

        [JsonProperty("State")]
        public long State { get; set; }

        [JsonProperty("Updated")]
        public long Updated { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
      {
        ServerConverter.Singleton,
        new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
      },
        };
    }

    internal class ServerConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FFXIVServer) || t == typeof(FFXIVServer?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Enum.Parse(typeof(FFXIVServer), value);
            }
            throw new Exception("Cannot unmarshal type Server");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FFXIVServer)untypedValue;
            throw new Exception("Cannot marshal type Server");
        }

        public static readonly ServerConverter Singleton = new ServerConverter();
    }
}