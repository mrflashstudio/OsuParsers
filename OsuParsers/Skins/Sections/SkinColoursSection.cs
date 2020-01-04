using System.Collections.Generic;
using System.Drawing;

namespace OsuParsers.Skins.Sections
{
    public class SkinColoursSection
    {
        public List<Color> ComboColours { get; set; } = new List<Color>();
        public Color InputOverlayText { get; set; } = Color.Black;
        public Color MenuGlow { get; set; } = Color.FromArgb(128, 128, 160);
        public Color SliderBall { get; set; } = Color.FromArgb(2, 170, 255);
        public Color SliderBorder { get; set; } = Color.White;
        public Color SliderTrackOverride { get; set; } = default;
        public Color SongSelectActiveText { get; set; } = Color.Black;
        public Color SongSelectInactiveText { get; set; } = Color.White;
        public Color SpinnerBackground { get; set; } = Color.FromArgb(100, 100, 100);
        public Color StarBreakAdditive { get; set; } = Color.LightPink;
    }
}
