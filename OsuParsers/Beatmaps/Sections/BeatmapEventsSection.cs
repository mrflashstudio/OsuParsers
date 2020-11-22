using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Storyboards;
using System.Collections.Generic;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapEventsSection
    {
        public string BackgroundImage { get; set; }
        public string Video { get; set; }
        public int VideoOffset { get; set; }
        public List<BeatmapBreakEvent> Breaks { get; set; } = new List<BeatmapBreakEvent>();
        public Storyboard Storyboard { get; set; } = new Storyboard();
    }
}
