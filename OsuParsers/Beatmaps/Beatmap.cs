using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Helpers;
using System.Collections.Generic;
using System.IO;
using OsuParsers.Encoders;

namespace OsuParsers.Beatmaps
{
    public class Beatmap
    {
        public const int LATEST_OSZ_VERSION = 14;
        
        public int Version { get; set; } = LATEST_OSZ_VERSION;
        public BeatmapGeneralSection GeneralSection { get; set; } = new BeatmapGeneralSection();
        public BeatmapEditorSection EditorSection { get; set; } = new BeatmapEditorSection();
        public BeatmapMetadataSection MetadataSection { get; set; } = new BeatmapMetadataSection();
        public BeatmapDifficultySection DifficultySection { get; set; } = new BeatmapDifficultySection();
        public BeatmapEventsSection EventsSection { get; set; } = new BeatmapEventsSection();
        public BeatmapColoursSection ColoursSection { get; set; } = new BeatmapColoursSection();

        public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

        /// <summary>
        /// Returns nearest beat length from the given offset.
        /// </summary>
        /// <param name="offset">Time in song. Should be in milliseconds.</param>
        /// <returns></returns>
        public double BeatLengthAt(int offset)
        {
            if (TimingPoints.Count == 0)
                return 0;

            int timingPoint = 0;
            int samplePoint = 0;

            for (int i = 0; i < TimingPoints.Count; i++)
            {
                if (TimingPoints[i].Offset <= offset)
                {
                    if (TimingPoints[i].Inherited)
                        samplePoint = i;
                    else
                        timingPoint = i;
                }
            }

            double multiplier = 1;

            if (samplePoint > timingPoint && TimingPoints[samplePoint].BeatLength < 0)
                multiplier = MathHelper.CalculateBpmMultiplier(TimingPoints[samplePoint]);

            return TimingPoints[timingPoint].BeatLength * multiplier;
        }

        /// <summary>
        /// Saves this <see cref="Beatmap"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            File.WriteAllLines(path, BeatmapEncoder.Encode(this));
        }
    }
}
