using OsuBeatmapParser.Beatmaps.Objects;
using OsuBeatmapParser.Beatmaps.Sections;
using System.Collections.Generic;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps
{
    public class Beatmap
    {
        public int Version { get; set; }
        //TODO: make things in sections not "settable".
        public GeneralSection GeneralSection { get; private set; }
        public EditorSection EditorSection { get; private set; }
        public MetadataSection MetadataSection { get; private set; }
        public DifficultySection DifficultySection { get; private set; }
        public EventsSection EventsSection { get; private set; }

        public List<Color> Colours { get; private set; } = new List<Color>();
        public List<TimingPoint> TimingPoints { get; private set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; private set; } = new List<HitObject>();

        public Beatmap()
        {
            GeneralSection = new GeneralSection();
            EditorSection = new EditorSection();
            MetadataSection = new MetadataSection();
            DifficultySection = new DifficultySection();
            EventsSection = new EventsSection();
        }
    }
}
