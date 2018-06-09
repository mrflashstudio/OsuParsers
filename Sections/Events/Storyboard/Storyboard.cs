using System.Collections.Generic;

namespace OsuBeatmapParser.Sections.Events.Storyboard
{
    public class Storyboard
    {
        public List<StoryboardObject> Objects { get; private set; } = new List<StoryboardObject>();
        public List<object> Commands { get; private set; } = new List<object>(); //TODO: this comes later :p
    }
}
