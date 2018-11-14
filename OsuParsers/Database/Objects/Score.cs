using OsuParsers.Enums;
using System;

namespace OsuParsers.Database.Objects
{
    public class Score
    {
        public Ruleset Ruleset { get; set; }
        public int OsuVersion { get; set; }
        public string BeatmapMD5Hash { get; set; }
        public string PlayerName { get; set; }
        public string ReplayMD5Hash { get; set; }
        public ushort Count300 { get; set; }
        public ushort Count100 { get; set; }
        public ushort Count50 { get; set; }
        public ushort CountGeki { get; set; }
        public ushort CountKatu { get; set; }
        public ushort CountMiss { get; set; }
        public int ReplayScore { get; set; }
        public ushort Combo { get; set; }
        public bool PerfectCombo { get; set; }
        public Mods Mods { get; set; }
        public DateTime ScoreTimestamp { get; set; }
        public long ScoreId { get; set; }
    }
}
