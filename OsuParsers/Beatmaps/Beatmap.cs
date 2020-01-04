using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Helpers;
using System.Collections.Generic;
using System.IO;

namespace OsuParsers.Beatmaps
{
    public class Beatmap
    {
        public int Version { get; set; }
        public BeatmapGeneralSection GeneralSection { get; set; }
        public BeatmapEditorSection EditorSection { get; set; }
        public BeatmapMetadataSection MetadataSection { get; set; }
        public BeatmapDifficultySection DifficultySection { get; set; }
        public BeatmapEventsSection EventsSection { get; set; }
        public BeatmapColoursSection ColoursSection { get; set; }

        public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

        public Beatmap()
        {
            GeneralSection = new BeatmapGeneralSection();
            EditorSection = new BeatmapEditorSection();
            MetadataSection = new BeatmapMetadataSection();
            DifficultySection = new BeatmapDifficultySection();
            EventsSection = new BeatmapEventsSection();
            ColoursSection = new BeatmapColoursSection();
        }

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
                        timingPoint = i;
                    else
                        samplePoint = i;
                }
            }

            double multiplier = 1;

            if (samplePoint > timingPoint && TimingPoints[samplePoint].BeatLength < 0)
                multiplier = MathHelper.CalculateBpmMultiplier(TimingPoints[samplePoint]);

            return TimingPoints[timingPoint].BeatLength * multiplier;
        }

        /// <summary>
        /// Writes this <see cref="Beatmap"/> to the specified path.
        /// </summary>
        public void Write(string path)
        {
            File.WriteAllLines(path, Writers.BeatmapWriter.Write(this));
        }
    }
}
