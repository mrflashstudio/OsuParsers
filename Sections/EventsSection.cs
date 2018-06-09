using OsuBeatmapParser.Sections.Events;
using OsuBeatmapParser.Sections.Events.Storyboard;
using System.Collections.Generic;

namespace OsuBeatmapParser.Sections
{
    public class EventsSection
    {
        public string BackgroundImage { get; set; }
        public string Video { get; set; }
        public int VideoOffset { get; set; }
        public List<BreakEvent> Breaks { get; private set; } = new List<BreakEvent>();
        public Storyboard Storyboard { get; private set; } = new Storyboard();
    }
}
