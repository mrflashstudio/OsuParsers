using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Enums;
using OsuParsers.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace OsuParsers.Beatmaps
{
    public class Beatmap
    {
        public int Version { get; set; }
        public GeneralSection GeneralSection { get; set; }
        public EditorSection EditorSection { get; set; }
        public MetadataSection MetadataSection { get; set; }
        public DifficultySection DifficultySection { get; set; }
        public EventsSection EventsSection { get; set; }

        public List<Color> Colours { get; set; } = new List<Color>();
        public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

        public Beatmap()
        {
            GeneralSection = new GeneralSection();
            EditorSection = new EditorSection();
            MetadataSection = new MetadataSection();
            DifficultySection = new DifficultySection();
            EventsSection = new EventsSection();
        }

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

        public void Write(string path)
        {
            File.WriteAllLines(path, Writers.BeatmapWriter.Write(this));
        }
    }
}
