using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
    public class LoopCommand : IHasCommands
    {
        public int LoopStartTime;
        public int LoopCount;

        public CommandGroup Commands { get; } = new CommandGroup();

        public LoopCommand(int startTime, int loopCount)
        {
            LoopStartTime = startTime;
            LoopCount = loopCount;
        }
    }
}
