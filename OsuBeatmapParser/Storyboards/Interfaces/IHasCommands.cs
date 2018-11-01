using OsuBeatmapParser.Storyboards.Commands;

namespace OsuBeatmapParser.Storyboards.Interfaces
{
    public interface IHasCommands
    {
        CommandGroup Commands { get; }
    }
}
