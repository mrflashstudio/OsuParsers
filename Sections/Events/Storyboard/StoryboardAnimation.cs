using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Sections.Events.Storyboard
{
    public class StoryboardAnimation : StoryboardObject
    {
        public StoryboardLayer Layer { get; private set; }
        public StoryboardOrigin Origin { get; private set; }
        public string FilePath { get; private set; }
        public Point Position { get; private set; }
        public int FrameCount { get; private set; }
        public int FrameDelay { get; private set; }
        public LoopType LoopType { get; private set; }

        public StoryboardAnimation(StoryboardLayer layer, StoryboardOrigin origin, string filePath, Point position,
            int frameCount, int frameDelay, LoopType loopType)
        {
            Layer = layer;
            Origin = origin;
            FilePath = filePath;
            Position = position;
            FrameCount = frameCount;
            FrameDelay = frameDelay;
            LoopType = loopType;
        }
    }
}
