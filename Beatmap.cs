using OsuBeatmapParser.Objects;
using OsuBeatmapParser.Sections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OsuBeatmapParser
{
    public class Beatmap
    {
        public int Version { get; set; }
        public GeneralSection GeneralSection { get; private set; }
        public EditorSection EditorSection { get; private set; }
        public MetadataSection MetadataSection { get; private set; }
        public DifficultySection DifficultySection { get; private set; }

        //TODO: make this not "settable"
        public List<Color> Colours { get; private set; } = new List<Color>();
        public List<TimingPoint> TimingPoints { get; private set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; private set; } = new List<HitObject>();

        public Beatmap()
        {
            GeneralSection = new GeneralSection();
            EditorSection = new EditorSection();
            MetadataSection = new MetadataSection();
            DifficultySection = new DifficultySection();
        }
    }
}
