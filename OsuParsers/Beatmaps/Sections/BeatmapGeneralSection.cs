using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapGeneralSection
    {
        public string AudioFilename { get; set; }
        public int AudioLeadIn { get; set; }
        public int PreviewTime { get; set; } = -1;
        public bool Countdown { get; set; } = true;
        public SampleSet SampleSet { get; set; } = SampleSet.Normal;
        public double StackLeniency { get; set; } = 0.7f;
        public Ruleset Mode { get; set; } = Ruleset.Standard;
        public int ModeId { get; set; }
        public bool LetterboxInBreaks { get; set; }
        public bool WidescreenStoryboard { get; set; }
        public bool StoryFireInFront { get; set; }
        public bool SpecialStyle { get; set; }
        public bool EpilepsyWarning { get; set; }
        public bool UseSkinSprites { get; set; }
        public int CirclesCount { get; set; }
        public int SlidersCount { get; set; }
        public int SpinnersCount { get; set; }
        public int Length { get; set; }
    }
}
