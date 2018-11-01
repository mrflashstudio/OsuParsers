using OsuBeatmapParser.Enums;

namespace OsuBeatmapParser.Storyboards.Interfaces
{
    public interface ICommand
    {
        Easing Easing { get; set; }
        int StartTime { get; set; }
        int EndTime { get; set; }
    }
}
