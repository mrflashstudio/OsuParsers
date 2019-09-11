using OsuParsers.Enums;
using OsuParsers.Enums.Replays;
using OsuParsers.Helpers;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;
using OsuParsers.Replays.SevenZip;
using OsuParsers.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace OsuParsers.Decoders
{
    public static class ReplayDecoder
    {
        /// <summary>
        /// Parses .osr file.
        /// </summary>
        /// <param name="path">Path to the .osr file.</param>
        /// <returns>A usable <see cref="Replay"/>.</returns>
        public static Replay Decode(string path)
        {
            if (File.Exists(path))
                return Decode(new FileStream(path, FileMode.Open));
            else
                throw new FileNotFoundException();
        }

        /// <summary>
        /// Parses .osr file.
        /// </summary>
        /// <param name="stream">Stream containing replay data.</param>
        /// <returns>A usable <see cref="Replay"/>.</returns>
        public static Replay Decode(Stream stream)
        {
            Replay replay = new Replay();
            SerializationReader r = new SerializationReader(stream);

            replay.Ruleset = (Ruleset)r.ReadByte();
            replay.OsuVersion = r.ReadInt32();
            replay.BeatmapMD5Hash = r.ReadString();
            replay.PlayerName = r.ReadString();
            replay.ReplayMD5Hash = r.ReadString();
            replay.Count300 = r.ReadUInt16();
            replay.Count100 = r.ReadUInt16();
            replay.Count50 = r.ReadUInt16();
            replay.CountGeki = r.ReadUInt16();
            replay.CountKatu = r.ReadUInt16();
            replay.CountMiss = r.ReadUInt16();
            replay.ReplayScore = r.ReadInt32();
            replay.Combo = r.ReadUInt16();
            replay.PerfectCombo = r.ReadBoolean();
            replay.Mods = (Mods)r.ReadInt32();

            string lifeData = r.ReadString();
            if (!string.IsNullOrEmpty(lifeData))
            {
                foreach (string lifeBlock in lifeData.Split(','))
                {
                    string[] split = lifeBlock.Split('|');
                    if (split.Length < 2)
                        continue;

                    replay.LifeFrames.Add(new LifeFrame()
                    {
                        Time = Convert.ToInt32(split[0]),
                        Percentage = ParseHelper.ToFloat(split[1])
                    });
                }
            }

            replay.ReplayTimestamp = r.ReadDateTime();
            replay.ReplayLength = r.ReadInt32();

            if (replay.ReplayLength > 0)
            {
                byte[] replayDataBytes = r.ReadBytes(replay.ReplayLength);
                byte[] decompressedBytes = LZMAHelper.Decompress(replayDataBytes);
                string decompressedString = Encoding.ASCII.GetString(decompressedBytes);
                int lastTime = 0;

                foreach (string frame in decompressedString.Split(','))
                {
                    if (string.IsNullOrEmpty(frame))
                        continue;

                    string[] split = frame.Split('|');

                    if (split.Length < 4)
                        continue;

                    if (split[0] == "-12345")
                    {
                        replay.Seed = Convert.ToInt32(split[3]);
                        continue;
                    }

                    ReplayFrame replayFrame = new ReplayFrame();
                    replayFrame.TimeDiff = Convert.ToInt32(split[0]);
                    replayFrame.Time = Convert.ToInt32(split[0]) + lastTime;
                    replayFrame.X = ParseHelper.ToFloat(split[1]);
                    replayFrame.Y = ParseHelper.ToFloat(split[2]);
                    switch (replay.Ruleset)
                    {
                        case Ruleset.Standard:
                            replayFrame.StandardKeys = (StandardKeys)Convert.ToInt32(split[3]);
                            break;
                        case Ruleset.Taiko:
                            replayFrame.TaikoKeys = (TaikoKeys)Convert.ToInt32(split[3]);
                            break;
                        case Ruleset.Fruits:
                            replayFrame.CatchKeys = (CatchKeys)Convert.ToInt32(split[3]);
                            break;
                        case Ruleset.Mania:
                            replayFrame.ManiaKeys = (ManiaKeys)replayFrame.X;
                            break;
                    }

                    replay.ReplayFrames.Add(replayFrame);

                    lastTime = replay.ReplayFrames.Last().Time;
                }
            }

            if (r.BaseStream.Length - r.BaseStream.Position > 0)
            {
                if (r.BaseStream.Length - r.BaseStream.Position == 4)
                    replay.OnlineId = r.ReadInt32();
                else
                    replay.OnlineId = r.ReadInt64();
            }

            return replay;
        }
    }
}
