using OsuParsers.Storyboards.Commands;

namespace OsuParsers.Storyboards.Interfaces
{
    public interface IHasCommands
    {
        CommandGroup Commands { get; }
    }
}
