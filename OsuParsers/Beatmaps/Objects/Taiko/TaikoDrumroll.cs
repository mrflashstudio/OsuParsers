using System;
using System.Collections.Generic;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    class TaikoDrumroll : Slider
    {
        public TaikoDrumroll(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, 
            int comboOffset, CurveType type, List<Point> points, int repeats, double pixelLength, 
            List<HitSoundType> edgeHitSounds, Tuple<SampleSet, SampleSet>[] edgeAdditions, Extras extras) 
            : base(position, startTime, endTime, hitSound, isNewCombo, comboOffset, type, points, repeats, pixelLength, edgeHitSounds, edgeAdditions, extras)
        {
        }
    }
}
