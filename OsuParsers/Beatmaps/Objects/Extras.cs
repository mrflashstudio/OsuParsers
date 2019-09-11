using OsuParsers.Enums.Beatmaps;

namespace OsuParsers.Beatmaps.Objects
{
    public class Extras
    {
        public Extras() { }
        public Extras(SampleSet sampleSet, SampleSet additionSet, int customIndex, int volume, string sampleFileName)
        {
            SampleSet = sampleSet;
            AdditionSet = additionSet;
            CustomIndex = customIndex;
            Volume = volume;
            SampleFileName = sampleFileName;
        }

        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSet { get; set; }
        public int CustomIndex { get; set; }
        public int Volume { get; set; }
        public string SampleFileName { get; set; }
    }
}
