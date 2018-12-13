using OsuParsers.Enums;
using OsuParsers.Storyboards.Interfaces;
using System;
using System.Drawing;

namespace OsuParsers.Storyboards.Commands
{
    public class Command : ICommand
    {
        public CommandType Type { get; set; }
        public Easing Easing { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Color StartColour { get; set; }
        public Color EndColour { get; set; }
        //refusing to use vector2 again
        public Tuple<float, float> StartVector { get; set; }
        public Tuple<float, float> EndVector { get; set; }
        public float StartFloat { get; set; }
        public float EndFloat { get; set; }

        public Command(CommandType type, Easing easing, int startTime, int endTime, float startValue, float endValue)
        {
            Type = type;
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            StartFloat = startValue;
            EndFloat = endValue;
        }

        public Command(CommandType type, Easing easing, int startTime, int endTime, Tuple<float, float> startValue, Tuple<float, float> endValue)
        {
            Type = type;
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            StartVector = startValue;
            EndVector = endValue;
        }

        public Command(Easing easing, int startTime, int endTime, Color startValue, Color endValue)
        {
            Type = CommandType.Colour;
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            StartColour = startValue;
            EndColour = endValue;
        }

        public Command(CommandType type, Easing easing, int startTime, int endTime)
        {
            Type = type;
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string GetAcronym()
        {
            switch (Type)
            {
                case CommandType.None:
                    return @"None";
                case CommandType.MovementX:
                    return @"MX";
                case CommandType.MovementY:
                    return @"MY";
                case CommandType.BlendingMode:
                case CommandType.FlipHorizontal:
                case CommandType.FlipVertical:
                    return @"P";
                default:
                    return Type.ToString().Substring(0, 1);
            }
        }
    }
}
