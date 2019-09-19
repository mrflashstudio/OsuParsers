using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Objects
{
    public class StoryboardAnimation : IStoryboardObject, IHasCommands
    {
        public CommandGroup Commands { get; } = new CommandGroup();
        public Origins Origin;
        public string FilePath { get; set; }
        public float X;
        public float Y;
        public int FrameCount;
        public double FrameDelay;
        public LoopType LoopType;

        public StoryboardAnimation(Origins origin, string filePath, float x, float y, int frameCount, double frameDelay,
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
