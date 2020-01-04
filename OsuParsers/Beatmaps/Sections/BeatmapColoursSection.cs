using System.Collections.Generic;
using System.Drawing;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapColoursSection
    {
        public List<Color> ComboColours { get; set; } = new List<Color>();
        public Color SliderTrackOverride { get; set; }
        public Color SliderBorder { get; set; }
    }
}
