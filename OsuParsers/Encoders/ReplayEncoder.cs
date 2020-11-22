using OsuParsers.Enums;
using OsuParsers.Helpers;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using OsuParsers.Replays.SevenZip;
using OsuParsers.Serialization;
using System.IO;
using System.Text;

namespace OsuParsers.Encoders
{
    internal class ReplayEncoder
    {
        public static void Encode(Replay replay, string path)
        {
            using (SerializationWriter writer = new SerializationWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.Write((byte)replay.Ruleset);
                writer.Write(replay.OsuVersion);
                writer.Write(replay.BeatmapMD5Hash);
                writer.Write(replay.PlayerName);
                writer.Write(replay.ReplayMD5Hash);
                writer.Write(replay.Count300);
                writer.Write(replay.Count100);
                writer.Write(replay.Count50);
                writer.Write(replay.CountGeki);
                writer.Write(replay.CountKatu);
                writer.Write(replay.CountMiss);
                writer.Write(replay.ReplayScore);
                writer.Write(replay.Combo);
                writer.Write(replay.PerfectCombo);
                writer.Write((int)replay.Mods);

                string lifeFrames = null;
                foreach (LifeFrame frame in replay.LifeFrames)
                    lifeFrames += $"{frame.Time.Format()}|{frame.Percentage.Format()},";
                writer.Write(lifeFrames);

                writer.Write(replay.ReplayTimestamp.ToUniversalTime().Ticks);

                if (replay.ReplayFrames.Count == 0)
                    writer.Write(0);
                else
                {
                    string replayFrames = string.Empty;
                    foreach (ReplayFrame frame in replay.ReplayFrames)
                    {
                        int keys = 0;
                        switch (replay.Ruleset)
                        {
                            case Ruleset.Standard:
                                keys = (int)frame.StandardKeys;
                                break;
                            case Ruleset.Taiko:
                                keys = (int)frame.TaikoKeys;
                                break;
                            case Ruleset.Fruits:
                                keys = (int)frame.CatchKeys;
                                break;
                            case Ruleset.Mania:
                                keys = (int)frame.ManiaKeys;
                                break;
                        }

                        replayFrames += $"{frame.TimeDiff}|{frame.X.Format()}|{frame.Y.Format()}|{keys},";
                    }

                    byte[] rawBytes = Encoding.ASCII.GetBytes(replayFrames);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(rawBytes, 0, rawBytes.Length);

                        MemoryStream codedStream = LZMAHelper.Compress(ms);
                        byte[] rawBytesCompressed = new byte[codedStream.Length];
                        codedStream.Read(rawBytesCompressed, 0, rawBytesCompressed.Length);

                        writer.Write(rawBytesCompressed.Length);
                        writer.Write(rawBytesCompressed);
                    }
                }

                writer.Write(replay.OnlineId);
            }
        }
    }
}
