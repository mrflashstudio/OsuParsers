using OsuParsers.Enums;
using OsuParsers.Enums.Database;
using System;

namespace OsuParsers.Database.Objects
{
    public class Player
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Timezone { get; set; }
        public byte CountryCode { get; set; }
        public Permissions Permissions { get; set; }
        public Ruleset Ruleset { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Rank { get; set; }
        public DateTime LastUpdateTime { get; set; } //probably
    }
}
