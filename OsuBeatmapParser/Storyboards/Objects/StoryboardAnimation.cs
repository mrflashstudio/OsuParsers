using OsuBeatmapParser.Enums;
using OsuBeatmapParser.Storyboards.Commands;
using OsuBeatmapParser.Storyboards.Interfaces;

namespace OsuBeatmapParser.Storyboards.Objects
{
    public class StoryboardAnimation : IStoryboardObject, IHasCommands
    {
        public CommandGroup Commands { get; } = new CommandGroup();
        public Origins Origin;
        public string FilePath { get; set; }
        public float X;
        public float Y;
        public int FrameCount;
        public int FrameDelay;
        public LoopType LoopType;

        public StoryboardAnimation(Origins origin, string filePath, float x, float y, int frameCount, int frameDelay,
            LoopType loopType)
        {
            Origin = origin;
            FilePath = filePath;
            X = x;
            Y = y;
            FrameCount = frameCount;
            FrameDelay = frameDelay;
            LoopType = loopType;
        }
    }
}
