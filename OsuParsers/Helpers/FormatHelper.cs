using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Standard;
using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string HitObject(HitObject hitObject)
        {
            var x = hitObject.Position.X;
            var y = hitObject.Position.Y;
            var time = hitObject.StartTime;
            var hitsound = (int)hitObject.HitSound;
            var extras = HitObjectExtras(hitObject.Extras);
            int type;
            
            //TODO: add proper type implementation
            //TODO: add all object types

            if (hitObject is StandardHitCircle standardHitCircle)
            {
                type = (Bool(standardHitCircle.IsNewCombo) * 4) + 1;
                return $"{x},{y},{time},{type},{hitsound},{extras}";
            }
            if (hitObject is StandardSlider standardSlider)
            {
                type = (Bool(standardSlider.IsNewCombo) * 4) + 2;
                return $"{x},{y},{time},{type},{hitsound},{SliderProperties(standardSlider)},{extras}";
            }
            if (hitObject is StandardSpinner standardSpinner)
            {
                type = (Bool(standardSpinner.IsNewCombo) * 4) + 8;
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
