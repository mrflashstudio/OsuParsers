using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Globalization;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;
using OsuParsers.Storyboards.Commands;

namespace OsuParsers.Helpers
{
    internal class FormatHelper
    {
        public static string Join(IEnumerable<string> vs, char splitter = ' ')
        {
            if (vs != null)
            {
                string owo = string.Empty;
                vs.ToList().ForEach(e => owo += e + splitter);
                return owo.TrimEnd(splitter);
            }
            else
                return string.Empty;
        }

        public static string Join(IEnumerable<int> vs, char splitter = ' ')
        {
            if (vs != null)
            {
                List<string> x = vs.ToList().ConvertAll(e => e.ToString());
                return Join(x, splitter);
            }
            else
                return string.Empty;
        }

        public static int Bool(bool value) => value ? 1 : 0;

        public static string TimingPoint(TimingPoint timingPoint)
        {
            var offset = timingPoint.Offset;
            var msPerBeat = timingPoint.BeatLength.Format();
            var meter = (int)timingPoint.TimeSignature;
            var sampleSet = (int)timingPoint.SampleSet;
            var sampleIndex = timingPoint.CustomSampleSet;
            var volume = timingPoint.Volume;
            var inherited = Bool(timingPoint.Inherited);
            var effects = (int)timingPoint.Effects;

            return $"{offset},{msPerBeat},{meter},{sampleSet},{sampleIndex},{volume},{inherited},{effects}";
        }

        public static string Colour(Color colour, int index)
        {
            var combo = $"Combo{index}";
            var r = colour.R;
            var g = colour.G;
            var b = colour.B;

            return $"{combo} : {r},{g},{b}";
        }

        public static string HitObject(HitObject hitObject)
        {
            var x = hitObject.Position.X;
            var y = hitObject.Position.Y;
            var time = hitObject.StartTime;
            var hitsound = (int)hitObject.HitSound;
            var extras = HitObjectExtras(hitObject.Extras);
            int type = TypeByte(hitObject);

            string hitObjectBase = $"{x},{y},{time},{type},{hitsound}";
            string extra = ",";

            if (hitObject is Circle && !(hitObject is ManiaHold))
            {
                extra += extras;
            }
            if (hitObject is Slider slider)
            {
                extra +=  SliderProperties(slider) + (slider.EdgeHitSounds == null ? string.Empty : $",{extras}");
            }
            if (hitObject is Spinner spinner)
            {
                extra +=  $"{spinner.EndTime},{extras}";
            }
            if (hitObject is ManiaHold hold)
            {
                extra += $"{hold.EndTime}:{extras}";
            }

            return hitObjectBase + extra;
        }

        public static string SliderProperties(Slider slider)
        {
            var sliderType = CurveType(slider.CurveType);

            string sliderPoints = string.Empty;
            slider.SliderPoints.ForEach(pt => sliderPoints += $"|{pt.X}:{pt.Y}");

            var repeats = slider.Repeats;
            var pixelLength = slider.PixelLength.Format();

            if (slider.EdgeHitSounds == null)
            {
                return $"{sliderType}{sliderPoints},{repeats},{pixelLength}";
            }
            else
            {
                string edgeHitsounds = string.Empty;
                slider.EdgeHitSounds.ForEach(sound => edgeHitsounds += $"{(int)sound}|");
                edgeHitsounds = edgeHitsounds.TrimEnd('|');

                string edgeAdditions = string.Empty;
                slider.EdgeAdditions.ToList().ForEach(e => edgeAdditions += $"{(int)e.Item1}:{(int)e.Item2}|");
                edgeAdditions = edgeAdditions.Trim('|');

                return $"{sliderType}{sliderPoints},{repeats},{pixelLength},{edgeHitsounds},{edgeAdditions}";
            }
        }

        public static char CurveType(CurveType value)
        {
            switch (value)
            {
                case Enums.CurveType.Bezier:
                    return 'B';
                case Enums.CurveType.Catmull:
                    return 'C';
                case Enums.CurveType.Linear:
                    return 'L';
                case Enums.CurveType.PerfectCurve:
                    return 'P';
                default:
                    throw new InvalidCastException();
            }
        }

        public static int TypeByte(HitObject hitObject)
        {
            int i = 0;
            if (hitObject is Circle && !(hitObject is ManiaHold))
                i += 1 << 0;
            if (hitObject is Slider)
                i += 1 << 1;
            if (hitObject is Spinner)
                i += 1 << 3; 
            if (hitObject.IsNewCombo)
                i += 1 << 2;
            if (hitObject is ManiaHold)
                i += 1 << 7;
            i += hitObject.ComboOffset << 4;
            return i;
        }

        public static string HitObjectExtras(Extras extras)
        {
            var sampleSet = (int)extras.SampleSet;
            var additionSet = (int)extras.AdditionSet;
            var customIndex = extras.CustomIndex;
            var sampleVolume = extras.Volume;
            var filename = extras.SampleFileName ?? string.Empty;
            return $"{sampleSet}:{additionSet}:{customIndex}:{sampleVolume}:{filename}";
        }

        public static List<string> StoryboardObject(IStoryboardObject storyboardObject, StoryboardLayer layer)
        {
            List<string> list = new List<string>();

            if (storyboardObject is StoryboardSprite sprite)
                list.Add($"Sprite,{layer},{sprite.Origin},\"{sprite.FilePath}\",{sprite.X.Format()},{sprite.Y.Format()}");
            else if (storyboardObject is StoryboardAnimation animation)
                list.Add($"Animation,{layer},{animation.Origin},\"{animation.FilePath}\",{animation.X.Format()},{animation.Y.Format()},{animation.FrameCount},{animation.FrameDelay},{animation.LoopType}");
            else if(storyboardObject is StoryboardSample sample)
                list.Add($"Sample,{sample.Time},{layer},\"{sample.FilePath}\",{sample.Volume}");

            if (storyboardObject is IHasCommands obj)
            {
                foreach (var loop in obj.Commands.Loops)
                {
                    list.Add($" L,{loop.LoopStartTime},{loop.LoopCount}");
                    foreach (var command in loop.Commands.Commands)
                    {
                        if (command.StartTime == command.EndTime)
                            list.Add($"  {command.GetAcronym()},{(int)command.Easing},{command.StartTime},,{GetCommandArguments(command)}");
                        else
                            list.Add($"  {command.GetAcronym()},{(int)command.Easing},{command.StartTime},{command.EndTime},{GetCommandArguments(command)}");
                    }
                }

                foreach (var command in obj.Commands.Commands)
                {
                    if (command.StartTime == command.EndTime)
                        list.Add($" {command.GetAcronym()},{(int)command.Easing},{command.StartTime},,{GetCommandArguments(command)}");
                    else
                        list.Add($" {command.GetAcronym()},{(int)command.Easing},{command.StartTime},{command.EndTime},{GetCommandArguments(command)}");
                }

                foreach (var trigger in obj.Commands.Triggers)
                {
                    if (trigger.TriggerEndTime == 0)
                        list.Add($" T,{trigger.TriggerName}{(trigger.GroupNumber != 0 ? $",{-trigger.GroupNumber}" : string.Empty)}");
                    else
                        list.Add($" T,{trigger.TriggerName},{trigger.TriggerStartTime},{trigger.TriggerEndTime}{(trigger.GroupNumber != 0 ? $",{-trigger.GroupNumber}" : string.Empty)}");

                    foreach (var command in trigger.Commands.Commands)
                    {
                        if (command.StartTime == command.EndTime)
                            list.Add($"  {command.GetAcronym()},{(int)command.Easing},{command.StartTime},,{GetCommandArguments(command)}");
                        else
                            list.Add($"  {command.GetAcronym()},{(int)command.Easing},{command.StartTime},{command.EndTime},{GetCommandArguments(command)}");
                    }
                }
            }

            return list;
        }

        private static string GetCommandArguments(Command command)
        {
            string arguments = string.Empty;
            switch (command.Type)
            {
                case CommandType.Movement:
                case CommandType.VectorScale:
                    if (command.StartVector.Equals(command.EndVector))
                        arguments = $"{command.StartVector.Item1.Format()},{command.StartVector.Item2.Format()}";
                    else
                        arguments = $"{command.StartVector.Item1.Format()},{command.StartVector.Item2.Format()},{command.EndVector.Item1.Format()},{command.EndVector.Item2.Format()}";
                    break;
                case CommandType.Fade:
                case CommandType.Rotation:
                case CommandType.Scale:
                case CommandType.MovementX:
                case CommandType.MovementY:
                    if (command.StartFloat == command.EndFloat)
                        arguments = $"{command.StartFloat.Format()}";
                    else
                        arguments = $"{command.StartFloat.Format()},{command.EndFloat.Format()}";
                    break;
                case CommandType.Colour:
                    if (command.StartColour == command.EndColour)
                        arguments = $"{command.StartColour.R},{command.StartColour.G},{command.StartColour.B}";
                    else
                        arguments = $"{command.StartColour.R},{command.StartColour.G},{command.StartColour.B},{command.EndColour.R},{command.EndColour.G},{command.EndColour.B}";
                    break;
                case CommandType.FlipHorizontal:
                    arguments = @"H";
                    break;
                case CommandType.FlipVertical:
                    arguments = @"V";
                    break;
                case CommandType.BlendingMode:
                    arguments = @"A";
                    break;
            }
            return arguments;
        }
    }

    static class Extensions
    {
        private static NumberFormatInfo NumFormat = new CultureInfo(@"en-US", false).NumberFormat;

        public static int Format(this bool value) => FormatHelper.Bool(value);
        public static string Format(this float value) => value.ToString(NumFormat);
        public static string Format(this double value) => value.ToString(NumFormat);
        public static string Format(this int value) => value.ToString(NumFormat);
    }
}
