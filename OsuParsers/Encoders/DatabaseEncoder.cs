using OsuParsers.Database;
using OsuParsers.Serialization;
using System.IO;
using System.Linq;

namespace OsuParsers.Encoders
{
    internal class DatabaseEncoder
    {
        public static void EncodeOsuDatabase(string path, OsuDatabase db)
        {
            using (SerializationWriter writer = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.Write(db.OsuVersion);
                writer.Write(db.FolderCount);
                writer.Write(db.AccountUnlocked);
                writer.Write(db.UnlockDate);
                writer.Write(db.PlayerName);
                writer.Write(db.BeatmapCount);

                foreach (var beatmap in db.Beatmaps)
                {
                    if (db.OsuVersion < 20191106)
                        writer.Write(beatmap.BytesOfBeatmapEntry);
                    writer.Write(beatmap.Artist);
                    writer.Write(beatmap.ArtistUnicode);
                    writer.Write(beatmap.Title);
                    writer.Write(beatmap.TitleUnicode);
                    writer.Write(beatmap.Creator);
                    writer.Write(beatmap.Difficulty);
                    writer.Write(beatmap.AudioFileName);
                    writer.Write(beatmap.MD5Hash);
                    writer.Write(beatmap.FileName);
                    writer.Write((byte)beatmap.RankedStatus);
                    writer.Write(beatmap.CirclesCount);
                    writer.Write(beatmap.SlidersCount);
                    writer.Write(beatmap.SpinnersCount);
                    writer.Write(beatmap.LastModifiedTime);
                    writer.Write(beatmap.ApproachRate);
                    writer.Write(beatmap.CircleSize);
                    writer.Write(beatmap.HPDrain);
                    writer.Write(beatmap.OverallDifficulty);
                    writer.Write(beatmap.SliderVelocity);
                    if (db.OsuVersion >= 20140609)
                    {
                        writer.Write(beatmap.StandardStarRating.ToDictionary(d => (int)d.Key, d => d.Value));
                        writer.Write(beatmap.TaikoStarRating.ToDictionary(d => (int)d.Key, d => d.Value));
                        writer.Write(beatmap.CatchStarRating.ToDictionary(d => (int)d.Key, d => d.Value));
                        writer.Write(beatmap.ManiaStarRating.ToDictionary(d => (int)d.Key, d => d.Value));
                    }
                    writer.Write(beatmap.DrainTime);
                    writer.Write(beatmap.TotalTime);
                    writer.Write(beatmap.AudioPreviewTime);
                    writer.Write(beatmap.TimingPoints.Count);
                    for (int j = 0; j < beatmap.TimingPoints.Count; j++)
                    {
                        writer.Write(beatmap.TimingPoints[j].BPM);
                        writer.Write(beatmap.TimingPoints[j].Offset);
                        writer.Write(!beatmap.TimingPoints[j].Inherited);
                    }
                    writer.Write(beatmap.BeatmapId);
                    writer.Write(beatmap.BeatmapSetId);
                    writer.Write(beatmap.ThreadId);
                    writer.Write((byte)beatmap.StandardGrade);
                    writer.Write((byte)beatmap.TaikoGrade);
                    writer.Write((byte)beatmap.CatchGrade);
                    writer.Write((byte)beatmap.ManiaGrade);
                    writer.Write(beatmap.LocalOffset);
                    writer.Write(beatmap.StackLeniency);
                    writer.Write((byte)beatmap.Ruleset);
                    writer.Write(beatmap.Source);
                    writer.Write(beatmap.Tags);
                    writer.Write(beatmap.OnlineOffset);
                    writer.Write(beatmap.TitleFont);
                    writer.Write(beatmap.IsUnplayed);
                    writer.Write(beatmap.LastPlayed);
                    writer.Write(beatmap.IsOsz2);
                    writer.Write(beatmap.FolderName);
                    writer.Write(beatmap.LastCheckedAgainstOsuRepo);
                    writer.Write(beatmap.IgnoreBeatmapSound);
                    writer.Write(beatmap.IgnoreBeatmapSkin);
                    writer.Write(beatmap.DisableStoryboard);
                    writer.Write(beatmap.DisableVideo);
                    writer.Write(beatmap.VisualOverride);
                    if (db.OsuVersion < 20140609)
                        writer.Write((short)0); //let's write 0 here for now
                    writer.Write(0); //and here
                    writer.Write(beatmap.ManiaScrollSpeed);
                }

                writer.Write((int)db.Permissions);
            }
        }

        public static void EncodeCollectionDatabase(string path, CollectionDatabase db)
        {
            using (SerializationWriter writer = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.Write(db.OsuVersion);
                writer.Write(db.CollectionCount);

                foreach (var collection in db.Collections)
                {
                    writer.Write(collection.Name);
                    writer.Write(collection.Count);

                    foreach (var hash in collection.MD5Hashes)
                        writer.Write(hash);
                }
            }
        }

        public static void EncodeScoresDatabase(string path, ScoresDatabase db)
        {
            using (SerializationWriter writer = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.Write(db.OsuVersion);
                writer.Write(db.Scores.Count);

                foreach (var beatmap in db.Scores)
                {
                    writer.Write(beatmap.Item1); //md5
                    writer.Write(beatmap.Item2.Count);

                    foreach (var score in beatmap.Item2) //scores
                    {
                        writer.Write((byte)score.Ruleset);
                        writer.Write(score.OsuVersion);
                        writer.Write(score.BeatmapMD5Hash);
                        writer.Write(score.PlayerName);
                        writer.Write(score.ReplayMD5Hash);
                        writer.Write(score.Count300);
                        writer.Write(score.Count100);
                        writer.Write(score.Count50);
                        writer.Write(score.CountGeki);
                        writer.Write(score.CountKatu);
                        writer.Write(score.CountMiss);
                        writer.Write(score.ReplayScore);
                        writer.Write(score.Combo);
                        writer.Write(score.PerfectCombo);
                        writer.Write((int)score.Mods);
                        writer.Write(string.Empty); //TODO: figure out what this is, probably life bar graph data
                        writer.Write(score.ScoreTimestamp);
                        writer.Write(-1); //Should always be -1
                        writer.Write(score.ScoreId);
                    }
                }
            }
        }

        public static void EncodePresenceDatabase(string path, PresenceDatabase db)
        {
            using (SerializationWriter writer = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.Write(db.OsuVersion);
                writer.Write(db.Players.Count);

                foreach (var player in db.Players)
                {
                    writer.Write(player.UserId);
                    writer.Write(player.Username);
                    writer.Write((byte)(player.Timezone + 24));
                    writer.Write(player.CountryCode);
                    writer.Write((byte)(((byte)player.Permissions & 0x1f) | (((byte)player.Ruleset & 0x7) << 5)));
                    writer.Write(player.Longitude);
                    writer.Write(player.Latitude);
                    writer.Write(player.Rank);
                    writer.Write(player.LastUpdateTime);
                }
            }
        }
    }
}
