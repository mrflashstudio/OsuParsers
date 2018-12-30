using System;
using System.Collections.Generic;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    class TaikoDrumroll : Slider
    {
        public bool IsBig { get; set; }

        public TaikoDrumroll(Point position, int startTime, int endTime, HitSoundType hitSound, CurveType type, 
            List<Point> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds, 
            Tuple<SampleSet, SampleSet>[] edgeAdditions, Extras extras, bool isBig) 
            : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, edgeHitSounds, edgeAdditions, extras, false, 0)
        {
            IsBig = isBig;
        }
    }
}
