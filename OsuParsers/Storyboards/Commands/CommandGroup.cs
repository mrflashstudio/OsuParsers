using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OsuParsers.Storyboards.Commands
{
    public class CommandGroup
    {
        public List<Command<float>> X = new List<Command<float>>();
        public List<Command<float>> Y = new List<Command<float>>();
        public List<Command<float>> Scale = new List<Command<float>>();
        //im still refusing to use vector2 :D
        public List<Command<Tuple<float, float>>> VectorScale = new List<Command<Tuple<float, float>>>();
        public List<Command<float>> Rotation = new List<Command<float>>();
        public List<Command<Color>> Colour = new List<Command<Color>>();
        public List<Command<float>> Alpha = new List<Command<float>>();
        public List<Command<BlendingMode>> BlendingMode = new List<Command<BlendingMode>>();
        public List<Command<bool>> FlipH = new List<Command<bool>>();
        public List<Command<bool>> FlipV = new List<Command<bool>>();

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
