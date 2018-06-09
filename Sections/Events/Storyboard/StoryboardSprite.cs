using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Sections.Events.Storyboard
{
    public class StoryboardSprite : StoryboardObject
    {
        public StoryboardLayer Layer { get; private set; }
        public StoryboardOrigin Origin { get; private set; }
        public string FilePath { get; private set; }
        public Point Position { get; private set; }

        public StoryboardSprite(StoryboardLayer layer, StoryboardOrigin origin, string filePath, Point position)
        {
            Layer = layer;
            Origin = origin;
            FilePath = filePath;
            Position = position;
        }
    }
}
