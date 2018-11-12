using OsuBeatmapParser.Enums;
using OsuBeatmapParser.Replays.Objects;
using System;
using System.Collections.Generic;

namespace OsuBeatmapParser.Replays
{
    public class Replay
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
        public DateTime ReplayTimestamp { get; set; }
        public int ReplayLength { get; set; }
        public List<ReplayFrame> ReplayFrames { get; private set; } = new List<ReplayFrame>();
        public List<LifeFrame> LifeFrames { get; private set; } = new List<LifeFrame>();
    }
}
