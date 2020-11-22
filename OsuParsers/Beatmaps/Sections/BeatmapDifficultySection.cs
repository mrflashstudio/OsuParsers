namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapDifficultySection
    {
        public float HPDrainRate { get; set; } = 5f;
        public float CircleSize { get; set; } = 5f;
        public float OverallDifficulty { get; set; } = 5f;
        public float ApproachRate { get; set; } = 5f;
        public double SliderMultiplier { get; set; } = 1.4;
        public double SliderTickRate { get; set; } = 1.0;
    }
}
