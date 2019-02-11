using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Storyboards;
using System.Collections.Generic;

namespace OsuParsers.Beatmaps.Sections
{
    public class EventsSection
    {
        public string BackgroundImage { get; set; }
        public string Video { get; set; }
        public int VideoOffset { get; set; }
        public List<BreakEvent> Breaks { get; private set; } = new List<BreakEvent>();
        public Storyboard Storyboard { get; set; } = new Storyboard();
    }
}
