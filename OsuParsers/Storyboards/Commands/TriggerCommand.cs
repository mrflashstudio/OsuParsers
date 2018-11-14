using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
    public class TriggerCommand : IHasCommands
    {
        public string TriggerName;
        public int TriggerStartTime;
        public int TriggerEndTime;
        public int GroupNumber;

        public CommandGroup Commands { get; } = new CommandGroup();

        public TriggerCommand(string triggerName, int startTime, int endTime, int groupNumber)
        {
            TriggerName = triggerName;
            TriggerStartTime = startTime;
            TriggerEndTime = endTime;
            GroupNumber = groupNumber;
        }
    }
}
