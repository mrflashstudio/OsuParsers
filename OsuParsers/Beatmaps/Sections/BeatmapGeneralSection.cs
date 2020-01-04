using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapGeneralSection
    {
        public string AudioFilename { get; set; }
        public int AudioLeadIn { get; set; }
        public int PreviewTime { get; set; }
        public bool Countdown { get; set; }
        public SampleSet SampleSet { get; set; }
        public double StackLeniency { get; set; }
        public Ruleset Mode { get; set; }
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
