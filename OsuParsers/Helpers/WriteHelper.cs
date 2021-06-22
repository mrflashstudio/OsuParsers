using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums.Beatmaps;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Interfaces;
using OsuParsers.Storyboards.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OsuParsers.Helpers
{
    internal class WriteHelper
    {
        public static string TimingPoint(TimingPoint timingPoint)
        {
            var offset = timingPoint.Offset;
            var msPerBeat = timingPoint.BeatLength.Format();
            var meter = (int)timingPoint.TimeSignature;
            var sampleSet = (int)timingPoint.SampleSet;
            var sampleIndex = timingPoint.CustomSampleSet;
            var volume = timingPoint.Volume;
            var uninherited = (!timingPoint.Inherited).ToInt32();
            var effects = (int)timingPoint.Effects;

            return $"{offset},{msPerBeat},{meter},{sampleSet},{sampleIndex},{volume},{uninherited},{effects}";
        }

        public static string Colour(Color colour)
        {
            var r = colour.R;
            var g = colour.G;
            var b = colour.B;

            return $"{r},{g},{b}";
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

            if (hitObject is HitCircle && !(hitObject is ManiaHoldNote))
                extra += extras;
            if (hitObject is Slider slider)
                extra += SliderProperties(slider) + ((slider.EdgeHitSounds == null || !slider.EdgeHitSounds.Any()) ? string.Empty : $",{extras}");
            if (hitObject is Spinner spinner)
                extra += $"{spinner.EndTime},{extras}";
            if (hitObject is ManiaHoldNote hold)
                extra += $"{hold.EndTime}:{extras}";

            return hitObjectBase + extra;
        }

        public static string SliderProperties(Slider slider)
        {
            var sliderType = CurveType(slider.CurveType);

            string sliderPoints = string.Empty;
            slider.SliderPoints.ForEach(pt => sliderPoints += $"|{pt.X}:{pt.Y}");

            var repeats = slider.Repeats;
            var pixelLength = slider.PixelLength.Format();

            if (slider.EdgeHitSounds != null && slider.EdgeHitSounds.Any())
            {
                string edgeHitsounds = string.Empty;
                slider.EdgeHitSounds.ForEach(sound => edgeHitsounds += $"{(int)sound}|");
                edgeHitsounds = edgeHitsounds.TrimEnd('|');

                if (slider.EdgeAdditions == null)
                    return $"{sliderType}{sliderPoints},{repeats},{pixelLength},{edgeHitsounds}";

                string edgeAdditions = string.Empty;
                slider.EdgeAdditions.ToList().ForEach(e => edgeAdditions += $"{(int)e.Item1}:{(int)e.Item2}|");
                edgeAdditions = edgeAdditions.Trim('|');

                return $"{sliderType}{sliderPoints},{repeats},{pixelLength},{edgeHitsounds},{edgeAdditions}";
            }
            else
                return $"{sliderType}{sliderPoints},{repeats},{pixelLength}";
        }

        public static char CurveType(CurveType value)
        {
            switch (value)
            {
                case Enums.Beatmaps.CurveType.Bezier:
                    return 'B';
                case Enums.Beatmaps.CurveType.Catmull:
                    return 'C';
                case Enums.Beatmaps.CurveType.Linear:
                    return 'L';
                case Enums.Beatmaps.CurveType.PerfectCurve:
                    return 'P';
                default:
                    throw new InvalidCastException();
            }
        }

        public static int TypeByte(HitObject hitObject)
        {
            int i = 0;
            if (hitObject is HitCircle && !(hitObject is ManiaHoldNote))
                i += (int)HitObjectType.Circle;
            if (hitObject is Slider)
                i += (int)HitObjectType.Slider;
            if (hitObject is Spinner)
                i += (int)HitObjectType.Spinner;
            if (hitObject is ManiaHoldNote)
                i += (int)HitObjectType.Hold;
            i += hitObject.IsNewCombo ? 1 << 2 : 0;
            i += hitObject.ComboOffset << 4;
            return i;
        }

        public static string HitObjectExtras(Extras extras)
        {
            if (extras == null)
                return $"0:0:0:0:";

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
            else if (storyboardObject is StoryboardSample sample)
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
            switch (command.Type)
            {
                case CommandType.Movement:
                case CommandType.VectorScale:
                    if (command.StartVector.Equals(command.EndVector))
                        return $"{command.StartVector.X.Format()},{command.StartVector.Y.Format()}";
                    else
                        return $"{command.StartVector.X.Format()},{command.StartVector.Y.Format()},{command.EndVector.X.Format()},{command.EndVector.Y.Format()}";
                case CommandType.Fade:
                case CommandType.Rotation:
                case CommandType.Scale:
                case CommandType.MovementX:
                case CommandType.MovementY:
                    if (command.StartFloat == command.EndFloat)
                        return $"{command.StartFloat.Format()}";
                    else
                        return $"{command.StartFloat.Format()},{command.EndFloat.Format()}";
                case CommandType.Colour:
                    if (command.StartColour == command.EndColour)
                        return $"{command.StartColour.R},{command.StartColour.G},{command.StartColour.B}";
                    else
                        return $"{command.StartColour.R},{command.StartColour.G},{command.StartColour.B},{command.EndColour.R},{command.EndColour.G},{command.EndColour.B}";
                case CommandType.FlipHorizontal:
                    return "H";
                case CommandType.FlipVertical:
                    return "V";
                case CommandType.BlendingMode:
                    return "A";
                default:
                    return string.Empty;
            }
        }

        public static List<string> BaseListFormat(string SectionName)
        {
            return new List<string>
            {
                string.Empty,
                $"[{SectionName}]",
            };
        }
    }
}
