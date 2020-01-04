using System.Collections.Generic;

namespace OsuParsers.Skins.Sections
{
    public class SkinGeneralSection
    {
        public string Author { get; set; } = string.Empty;
        public string Name { get; set; } = "Unknown";
        public double Version { get; set; } = 1.0;
        public bool IsLatestVersion { get; set; } = false;
        public int AnimationFramerate { get; set; } = -1;
        public bool AllowSliderBallTint { get; set; } = false;
        public bool ComboBurstRandom { get; set; } = false;
        public bool CursorCentre { get; set; } = true;
        public bool CursorExpand { get; set; } = true;
        public bool CursorRotate { get; set; } = true;
        public bool CursorTrailRotate { get; set; } = false;
        public List<int> CustomComboBurstSounds { get; set; } = new List<int>();
        public bool HitCircleOverlayAboveNumber { get; set; } = true;
        public bool LayeredHitSounds { get; set; } = true;
        public bool SliderBallFlip { get; set; } = false;
        public int SliderBallFrames { get; set; } = 10;
        public int SliderStyle { get; set; } = 2;
        public bool SpinnerFadePlayfield { get; set; } = false;
        public bool SpinnerFrequencyModulate { get; set; } = true;
        public bool SpinnerNoBlink { get; set; } = false;
    }
}
