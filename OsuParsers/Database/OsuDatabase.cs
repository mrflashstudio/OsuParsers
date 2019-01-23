using OsuParsers.Database.Objects;
using OsuParsers.Enums;
using System;
using System.Collections.Generic;

namespace OsuParsers.Database
{
    public class OsuDatabase
    {
        public int OsuVersion { get; set; }
        public int FolderCount { get; set; }
        public bool AccountUnlocked { get; set; }
        public DateTime UnlockDate { get; set; }
        public string PlayerName { get; set; }
        public int BeatmapCount { get; set; }
        public List<DbBeatmap> Beatmaps { get; private set; } = new List<DbBeatmap>();
        public Permissions Permissions { get; set; }
    }
}
