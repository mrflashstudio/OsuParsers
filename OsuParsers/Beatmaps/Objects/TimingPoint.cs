using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
    public class TimingPoint
    {
        public int Offset { get; set; }
        public double BeatLength { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public SampleSet SampleSet { get; set; }
        public int CustomSampleSet { get; set; }
        public int Volume { get; set; }
        public bool Inherited { get; set; }
        public Effects Effects { get; set; }
    }
}
