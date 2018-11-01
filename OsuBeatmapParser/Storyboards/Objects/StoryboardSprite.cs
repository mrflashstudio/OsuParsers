using OsuBeatmapParser.Enums;
using OsuBeatmapParser.Storyboards.Commands;
using OsuBeatmapParser.Storyboards.Interfaces;

namespace OsuBeatmapParser.Storyboards.Objects
{
    public class StoryboardSprite : IStoryboardObject, IHasCommands
    {
        public CommandGroup Commands { get; } = new CommandGroup();
        public Origins Origin;
        public string FilePath { get; set; }
        public float X;
        public float Y;

        public StoryboardSprite(Origins origin, string filePath, float x, float y)
        {
            Origin = origin;
            FilePath = filePath;
            X = x;
            Y = y;
        }
    }
}
