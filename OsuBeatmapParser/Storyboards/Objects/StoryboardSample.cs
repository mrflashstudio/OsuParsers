using OsuBeatmapParser.Storyboards.Interfaces;

namespace OsuBeatmapParser.Storyboards.Objects
{
    public class StoryboardSample : IStoryboardObject
    {
        public int Time;
        public string FilePath { get; set; }
        public int Volume;

        public StoryboardSample(int time, string filePath, int volume)
        {
            Time = time;
            FilePath = filePath;
            Volume = volume;
        }
    }
}
