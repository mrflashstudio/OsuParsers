using OsuParsers.Enums;
using OsuParsers.Enums.Database;
using System;
using System.Collections.Generic;

namespace OsuParsers.Database.Objects
{
    public class DbBeatmap
    {
        public int BytesOfBeatmapEntry { get; set; }
        public string Artist { get; set; }
        public string ArtistUnicode { get; set; }
        public string Title { get; set; }
        public string TitleUnicode { get; set; }
        public string Creator { get; set; }
        public string Difficulty { get; set; }
        public string AudioFileName { get; set; }
        public string MD5Hash { get; set; }
        public string FileName { get; set; }
        public RankedStatus RankedStatus { get; set; }
        public ushort CirclesCount { get; set; }
        public ushort SlidersCount { get; set; }
        public ushort SpinnersCount { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public float ApproachRate { get; set; }
        public float CircleSize { get; set; }
        public float HPDrain { get; set; }
        public float OverallDifficulty { get; set; }
        public double SliderVelocity { get; set; }
        public Dictionary<Mods, double> StandardStarRating { get; set; }
        public Dictionary<Mods, double> TaikoStarRating { get; set; }
        public Dictionary<Mods, double> CatchStarRating { get; set; }
        public Dictionary<Mods, double> ManiaStarRating { get; set; }
        public int DrainTime { get; set; }
        public int TotalTime { get; set; }
        public int AudioPreviewTime { get; set; }
        public List<DbTimingPoint> TimingPoints { get; private set; } = new List<DbTimingPoint>();
        public int BeatmapId { get; set; }
        public int BeatmapSetId { get; set; }
        public int ThreadId { get; set; }
        public Grade StandardGrade { get; set; }
        public Grade TaikoGrade { get; set; }
        public Grade CatchGrade { get; set; }
        public Grade ManiaGrade { get; set; }
        public short LocalOffset { get; set; }
        public float StackLeniency { get; set; }
        public Ruleset Ruleset { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public short OnlineOffset { get; set; }
        public string TitleFont { get; set; }
        public bool IsUnplayed { get; set; }
        public DateTime LastPlayed { get; set; }
        public bool IsOsz2 { get; set; }
        public string FolderName { get; set; }
        public DateTime LastCheckedAgainstOsuRepo { get; set; }
        public bool IgnoreBeatmapSound { get; set; }
        public bool IgnoreBeatmapSkin { get; set; }
        public bool DisableStoryboard { get; set; }
        public bool DisableVideo { get; set; }
        public bool VisualOverride { get; set; }
        public byte ManiaScrollSpeed { get; set; }
    }
}
