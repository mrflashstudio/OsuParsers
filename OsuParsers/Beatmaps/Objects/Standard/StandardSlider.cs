using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Standard
{
    public class StandardSlider : StandardHitObject
    {
        public CurveType CurveType { get; set; }
        public List<Point> SliderPoints { get; set; } = new List<Point>();
        public int Repeats { get; set;  }
        public float PixelLength { get; set; }
        public List<HitSoundType> EdgeHitSounds { get; set; }
        public Tuple<SampleSet, SampleSet>[] EdgeAdditions { get; set; }

        public StandardSlider(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, CurveType type,
            List<Point> points, int repeats, float pixelLength, List<HitSoundType> edgeHitSounds, Tuple<SampleSet, SampleSet>[] edgeAdditions, HitObjectExtras extras) 
            : base(position, startTime, endTime, hitSound, isNewCombo, comboOffset, extras)
        {
            CurveType = type;
            SliderPoints = points;
            Repeats = repeats;
            PixelLength = pixelLength;
            EdgeHitSounds = edgeHitSounds;
            EdgeAdditions = edgeAdditions;
        }
    }
}
