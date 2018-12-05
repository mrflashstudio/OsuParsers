using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects
{
    public class HitObjectExtras
    {
        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSet { get; set; }
        public int CustomIndex { get; set; }
        public int Volume { get; set; }
        public string SampleFileName { get; set; }
    }
}
