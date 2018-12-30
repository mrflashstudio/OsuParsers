using System;
using System.Collections.Generic;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects
{
    public class Slider : HitObject
    {
        public Slider(Point position, int startTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, CurveType type,
            List<Point> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds, Tuple<SampleSet, SampleSet>[] edgeAdditions, Extras extras) 
            : base(position, startTime, hitSound, extras)
        {
            CurveType = type;
            SliderPoints = points;
            Repeats = repeats;
            PixelLength = pixelLength;
            EdgeHitSounds = edgeHitSounds;
            EdgeAdditions = edgeAdditions;
        }

        public CurveType CurveType { get; set; }
        public List<Point> SliderPoints { get; set; } = new List<Point>();
        public int Repeats { get; set; }
        public double PixelLength { get; set; }
        public List<HitSoundType> EdgeHitSounds { get; set; }
        public Tuple<SampleSet, SampleSet>[] EdgeAdditions { get; set; }
    }
}
