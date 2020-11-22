using OsuParsers.Database.Objects;
using OsuParsers.Enums.Database;
using System;
using System.Collections.Generic;
using OsuParsers.Encoders;

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
        public List<DbBeatmap> Beatmaps { get; set; } = new List<DbBeatmap>();
        public Permissions Permissions { get; set; }

        /// <summary>
        /// Saves this <see cref="OsuDatabase"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            DatabaseEncoder.EncodeOsuDatabase(path, this);
        }
    }
}
