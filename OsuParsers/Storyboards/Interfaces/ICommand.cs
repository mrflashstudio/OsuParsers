using OsuParsers.Enums;

namespace OsuParsers.Storyboards.Interfaces
{
    public interface ICommand
    {
        Easing Easing { get; set; }
        int StartTime { get; set; }
        int EndTime { get; set; }
    }
}
