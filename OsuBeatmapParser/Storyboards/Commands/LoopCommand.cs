using OsuBeatmapParser.Storyboards.Interfaces;

namespace OsuBeatmapParser.Storyboards.Commands
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
