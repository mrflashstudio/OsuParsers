using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Enums;
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

        public void Write(string path)
        {
            File.WriteAllLines(path, Writers.BeatmapWriter.Write(this), System.Text.Encoding.Unicode);
        }
    }
}
