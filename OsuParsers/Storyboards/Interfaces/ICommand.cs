using OsuParsers.Enums.Storyboards;

namespace OsuParsers.Storyboards.Interfaces
{
    public interface ICommand
    {
        CommandType Type { get; set; }
        Easing Easing { get; set; }
        int StartTime { get; set; }
        int EndTime { get; set; }
    }
}
