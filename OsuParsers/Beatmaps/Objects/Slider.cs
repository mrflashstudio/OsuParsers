using OsuParsers.Enums.Beatmaps;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects
{
    public class Slider : HitObject
    {
        public Slider(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points,
            int repeats, double pixelLength, List<HitSoundType> edgeHitSounds, List<Tuple<SampleSet, SampleSet>> edgeAdditions,
            Extras extras, bool isNewCombo, int comboOffset)
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
            CurveType = type;
            SliderPoints = points;
            Repeats = repeats;
            PixelLength = pixelLength;
            EdgeHitSounds = edgeHitSounds;
            EdgeAdditions = edgeAdditions;
        }

        public Slider(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, List<Vector2> points,
            int repeats, double pixelLength, bool isNewCombo, int comboOffset)
            : base(position, startTime, endTime, hitSound, null, isNewCombo, comboOffset)
        {
            CurveType = type;
            SliderPoints = points;
            Repeats = repeats;
            PixelLength = pixelLength;
        }

        public CurveType CurveType { get; set; }
        public List<Vector2> SliderPoints { get; set; } = new List<Vector2>();
        public int Repeats { get; set; }
        public double PixelLength { get; set; }
        public List<HitSoundType> EdgeHitSounds { get; set; }
        public List<Tuple<SampleSet, SampleSet>> EdgeAdditions { get; set; }
    }
}
