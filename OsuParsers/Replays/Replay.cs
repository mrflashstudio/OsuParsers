using OsuParsers.Enums;
using OsuParsers.Replays.Objects;
using System;
using System.Collections.Generic;
using OsuParsers.Encoders;

namespace OsuParsers.Replays
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
        public List<ReplayFrame> ReplayFrames { get; set; } = new List<ReplayFrame>();
        public List<LifeFrame> LifeFrames { get; set; } = new List<LifeFrame>();
        public int Seed { get; set; }
        public long OnlineId { get; set; }

        /// <summary>
        /// Saves this <see cref="Replay"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            ReplayEncoder.Encode(this, path);
        }
    }
}
