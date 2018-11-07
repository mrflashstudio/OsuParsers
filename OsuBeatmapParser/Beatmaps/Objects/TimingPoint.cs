using OsuBeatmapParser.Enums;

namespace OsuBeatmapParser.Beatmaps.Objects
{
    public class TimingPoint
    {
        public int Offset { get; set; }
        public float BeatLength { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public SampleSet SampleSet { get; set; }
        public int CustomSampleSet { get; set; }
        public int Volume { get; set; }
        public bool Inherited { get; set; }
        public bool KiaiMode { get; set; }
    }
}
