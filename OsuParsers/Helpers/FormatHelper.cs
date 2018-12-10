using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Standard;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Beatmaps.Objects.Catch;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OsuParsers.Helpers
{
    public class FormatHelper
    {
        public static string Join(IEnumerable<string> vs, string splitter = " ")
        {
            if (vs != null)
            {
                string owo = string.Empty;
                vs.ToList().ForEach(e => owo += e + splitter);
                return owo.TrimEnd();
            }
            else
                return string.Empty;
        }

        public static string Join(IEnumerable<int> vs, string splitter = " ")
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
            var msPerBeat = timingPoint.BeatLength;
            var meter = (int)timingPoint.TimeSignature;
            var sampleSet = (int)timingPoint.SampleSet;
            var sampleIndex = timingPoint.CustomSampleSet;
            var volume = timingPoint.Volume;
            var inherited = Bool(timingPoint.Inherited);
            var kiaiMode = Bool(timingPoint.KiaiMode);

            return $"{offset},{msPerBeat},{meter},{sampleSet},{sampleIndex},{volume},{inherited},{kiaiMode}";
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

            //TODO: add proper type implementation
            //TODO: add all object types

            if (hitObject is StandardHitCircle standardHitCircle)
            {
                return $"{x},{y},{time},{type},{hitsound},{extras}";
            }
            if (hitObject is StandardSlider standardSlider)
            {
                return $"{x},{y},{time},{type},{hitsound},{SliderProperties(standardSlider)},{extras}";
            }
            if (hitObject is StandardSpinner standardSpinner)
            {
                return $"{x},{y},{time},{type},{hitsound},{standardSpinner.EndTime},{extras}";
            }
            throw new NotImplementedException();
        }

        public static string SliderProperties(StandardSlider slider)
        {
            var sliderType = CurveType(slider.CurveType);

            string sliderPoints = string.Empty;
            slider.SliderPoints.ForEach(pt => sliderPoints += $"|{pt.X}:{pt.Y}");

            var repeats = slider.Repeats;
            var pixelLength = slider.PixelLength;

            string edgeHitsounds = string.Empty;
            slider.EdgeHitSounds.ForEach(sound => edgeHitsounds += $"{(int)sound}|");

            string edgeAdditions = string.Empty;
            slider.EdgeAdditions.ToList().ForEach(e => edgeAdditions += $"{(int)e.Item1}:{(int)e.Item2}");

            return $"{sliderType},{sliderPoints},{repeats},{pixelLength},{edgeHitsounds},{edgeAdditions}";
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
            if (hitObject is StandardHitCircle || hitObject is TaikoHitCircle || hitObject is CatchHitCircle || hitObject is ManiaSingle)
                i += 1;
            if (hitObject is StandardSlider || hitObject is TaikoDrumroll || hitObject is CatchSlider)
                i += 2;
            if (hitObject is StandardSpinner || hitObject is TaikoSpinner || hitObject is CatchSpinner)
                i += 8;
            if ((hitObject as StandardHitObject)?.IsNewCombo ?? (hitObject as CatchHitObject)?.IsNewCombo ?? false)
                i += 4;
            if (hitObject is ManiaHold)
                i += 128;
            if (hitObject is StandardHitObject standardHitObject)
                i += standardHitObject.ComboOffset << 4;
            if (hitObject is CatchHitObject catchHitObject)
                i += catchHitObject.ComboOffset << 4;
            return i;
        }

        public static string HitObjectExtras(HitObjectExtras extras)
        {
            var sampleSet = (int)extras.SampleSet;
            var additionSet = (int)extras.AdditionSet;
            var customIndex = extras.CustomIndex;
            var sampleVolume = extras.Volume;
            var filename = extras.SampleFileName ?? string.Empty;
            return $"{sampleSet}:{additionSet}:{customIndex}:{sampleVolume}:{filename}";
        }
    }
}
