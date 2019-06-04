using OsuParsers.Enums;
using OsuParsers.Helpers;
using OsuParsers.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace OsuParsers.Decoders
{
    public class StoryboardDecoder
    {
        private IStoryboardObject lastDrawable;
        private CommandGroup commandGroup;

        private Storyboard storyboard;
        public Storyboard Decode(IEnumerable<string> lines)
        {
            storyboard = new Storyboard();
            lastDrawable = null;
            commandGroup = null;

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && !line.StartsWith("[Events]"))
                {
                    if (!line.StartsWith(" ") && !line.StartsWith("_"))
                        ParseSbObject(line);
                    else
                        ParseSbCommand(line);
                }
            }

            return storyboard;
        }

        public Storyboard Decode(Stream stream) => Decode(stream.ReadAllLines());

        private void ParseSbObject(string line)
        {
            string[] tokens = line.Split(',');
            EventType type = (EventType)Enum.Parse(typeof(EventType), tokens[0]);
            StoryboardLayer layer = (StoryboardLayer)Enum.Parse(typeof(StoryboardLayer), tokens[type == EventType.Sample ? 2 : 1]);

            switch (type)
            {
                case EventType.Sprite:
                    {
                        Origins origin = (Origins)Enum.Parse(typeof(Origins), tokens[2]);
                        string fileName = tokens[3].Trim('"');
                        float x = float.Parse(tokens[4], NumberFormatInfo.InvariantInfo);
                        float y = float.Parse(tokens[5], NumberFormatInfo.InvariantInfo);
                        storyboard.GetLayer(layer).Add(new StoryboardSprite(origin, fileName, x, y));
                        lastDrawable = storyboard.GetLayer(layer).Last();
                    }
                    break;
                case EventType.Animation:
                    {
                        Origins origin = (Origins)Enum.Parse(typeof(Origins), tokens[2]);
                        string fileName = tokens[3].Trim('"');
                        float x = float.Parse(tokens[4], NumberFormatInfo.InvariantInfo);
                        float y = float.Parse(tokens[5], NumberFormatInfo.InvariantInfo);
                        int frameCount = Convert.ToInt32(tokens[6]);
                        int frameDelay = Convert.ToInt32(tokens[7]);
                        LoopType loopType = (LoopType)Enum.Parse(typeof(LoopType), tokens[8]);
                        storyboard.GetLayer(layer).Add(new StoryboardAnimation(origin, fileName, x, y, frameCount, frameDelay, loopType));
                        lastDrawable = storyboard.GetLayer(layer).Last();
                    }
                    break;
                case EventType.Sample:
                    {
                        int time = Convert.ToInt32(tokens[1]);
                        string filePath = tokens[3].Trim('"');
                        int volume = tokens.Length > 4 ? Convert.ToInt32(tokens[4]) : 100;
                        storyboard.SamplesLayer.Add(new StoryboardSample(layer, time, filePath, volume));
                    }
                    break;
            }
        }

        private void ParseSbCommand(string line)
        {
            int depth = 0;
            while (line.StartsWith(" ") || line.StartsWith("_"))
            {
                ++depth;
                line = line.Substring(1);
            }

            if (depth < 2)
                commandGroup = (lastDrawable as IHasCommands).Commands;

            string[] tokens = line.Split(',');

            string type = tokens[0];
            switch (type)
            {
                case "T":
                {
                    string triggerName = tokens[1];
                    int startTime = Convert.ToInt32(tokens[2]);
                    int endTime = Convert.ToInt32(tokens[3]);
                    int groupNumber = tokens.Length > 4 ? Convert.ToInt32(tokens[4]) : 0;
                    commandGroup = commandGroup.AddTrigger(triggerName, startTime, endTime, groupNumber).Commands;
                }
                    break;
                case "L":
                {
                    int startTime = Convert.ToInt32(tokens[1]);
                    int loopCount = Convert.ToInt32(tokens[2]);
                    commandGroup = commandGroup.AddLoop(startTime, loopCount).Commands;
                }
                    break;
                default:
                {
                    if (string.IsNullOrEmpty(tokens[3]))
                        tokens[3] = tokens[2];

                    Easing easing = (Easing)Convert.ToInt32(tokens[1]);
                    int startTime = Convert.ToInt32(tokens[2]);
                    int endTime = Convert.ToInt32(tokens[3]);

                    switch (type)
                    {
                        case "F":
                        {
                            float startValue = ParseHelper.ToFloat(tokens[4]);
                            float endValue = tokens.Length > 5 ? ParseHelper.ToFloat(tokens[5]) : startValue;
                            commandGroup.Commands.Add(new Command(CommandType.Fade, easing, startTime, endTime, startValue, endValue));
                        }
                            break;
                        case "M":
                        {
                            float startX = ParseHelper.ToFloat(tokens[4]);
                            float startY = ParseHelper.ToFloat(tokens[5]);
                            float endX = tokens.Length > 6 ? ParseHelper.ToFloat(tokens[6]) : startX;
                            float endY = tokens.Length > 7 ? ParseHelper.ToFloat(tokens[7]) : startY;
                            commandGroup.Commands.Add(new Command(CommandType.Movement, easing, startTime, endTime, new Vector2(startX, startY), new Vector2(endX, endY)));
                         }
                            break;
                        case "MX":
                        {
                            float startValue = ParseHelper.ToFloat(tokens[4]);
                            float endValue = tokens.Length > 5 ? ParseHelper.ToFloat(tokens[5]) : startValue;
                            commandGroup.Commands.Add(new Command(CommandType.MovementX, easing, startTime, endTime, startValue, endValue));
                        }
                            break;
                        case "MY":
                        {
                            float startValue = ParseHelper.ToFloat(tokens[4]);
                            float endValue = tokens.Length > 5 ? ParseHelper.ToFloat(tokens[5]) : startValue;
                            commandGroup.Commands.Add(new Command(CommandType.MovementY, easing, startTime, endTime, startValue, endValue));
                        }
                            break;
                        case "S":
                        {
                            float startValue = ParseHelper.ToFloat(tokens[4]);
                            float endValue = tokens.Length > 5 ? ParseHelper.ToFloat(tokens[5]) : startValue;
                            commandGroup.Commands.Add(new Command(CommandType.Scale, easing, startTime, endTime, startValue, endValue));
                        }
                            break;
                        case "V":
                        {
                            float startX = ParseHelper.ToFloat(tokens[4]);
                            float startY = ParseHelper.ToFloat(tokens[5]);
                            float endX = tokens.Length > 6 ? ParseHelper.ToFloat(tokens[6]) : startX;
                            float endY = tokens.Length > 7 ? ParseHelper.ToFloat(tokens[7]) : startY;
                            commandGroup.Commands.Add(new Command(CommandType.VectorScale, easing, startTime, endTime,
                                new Vector2(startX, startY), new Vector2(endX, endY)));
                        }
                            break;
                        case "R":
                        {
                            float startValue = ParseHelper.ToFloat(tokens[4]);
                            float endValue = tokens.Length > 5 ? ParseHelper.ToFloat(tokens[5]) : startValue;
                            commandGroup.Commands.Add(new Command(CommandType.Rotation, easing, startTime, endTime, startValue, endValue));
                        }
                            break;
                        case "C":
                        {
                            float startRed = ParseHelper.ToFloat(tokens[4]);
                            float startGreen = ParseHelper.ToFloat(tokens[5]);
                            float startBlue = ParseHelper.ToFloat(tokens[6]);
                            float endRed = tokens.Length > 7 ? ParseHelper.ToFloat(tokens[7]) : startRed;
                            float endGreen = tokens.Length > 8 ? ParseHelper.ToFloat(tokens[8]) : startGreen;
                            float endBlue = tokens.Length > 9 ? ParseHelper.ToFloat(tokens[9]) : startBlue;
                            commandGroup.Commands.Add(new Command(easing, startTime, endTime,
                                Color.FromArgb(255, (int)startRed, (int)startGreen, (int)startBlue),
                                Color.FromArgb(255, (int)endRed, (int)endGreen, (int)endBlue)));
                        }
                            break;
                        case "P":
                        {
                            string parameter = tokens[4];

                            switch (parameter)
                            {
                                case "H":
                                    commandGroup.Commands.Add(new Command(CommandType.FlipHorizontal, easing, startTime, endTime));
                                    break;
                                case "V":
                                    commandGroup.Commands.Add(new Command(CommandType.FlipVertical, easing, startTime, endTime));
                                    break;
                                case "A":
                                    commandGroup.Commands.Add(new Command(CommandType.BlendingMode, easing, startTime, endTime));
                                    break;
                            }
                        }
                            break;
                    }
                }
                    break;
            }
        }
    }
}
