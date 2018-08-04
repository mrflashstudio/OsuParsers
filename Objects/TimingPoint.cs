namespace OsuBeatmapParser.Objects
{
    public class TimingPoint
    {
        public int Offset { get; set; }
        public float BeatLength { get; set; }
        public int Meter { get; set; }
        public int SampleType { get; set; }
        public int SampleSet { get; set; }
        public int Volume { get; set; }
        public bool Inherited { get; set; }
        public bool KiaiMode { get; set; }
    }
}
