using System.Collections.Generic;

namespace OsuParsers.Storyboards.Commands
{
    public class CommandGroup
    {
        public List<Command> Commands = new List<Command>();

        public List<TriggerCommand> Triggers = new List<TriggerCommand>();
        public List<LoopCommand> Loops = new List<LoopCommand>();

        public TriggerCommand AddTrigger(string triggerName, int startTime, int endTime, int groupNumber)
        {
            TriggerCommand trigger = new TriggerCommand(triggerName, startTime, endTime, groupNumber);
            Triggers.Add(trigger);
            return trigger;
        }

        public LoopCommand AddLoop(int startTime, int loopCount)
        {
            LoopCommand loop = new LoopCommand(startTime, loopCount);
            Loops.Add(loop);
            return loop;
        }
    }
}
