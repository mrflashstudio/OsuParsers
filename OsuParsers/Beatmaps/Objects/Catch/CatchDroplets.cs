using System;
using System.Collections.Generic;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    class CatchDroplets : Slider
    {
        public CatchDroplets(Point position, int startTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, CurveType type, 
            List<Point> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds, Tuple<SampleSet, SampleSet>[] edgeAdditions, Extras extras) 
            : base(position, startTime, hitSound, isNewCombo, comboOffset, type, points, repeats, pixelLength, edgeHitSounds, edgeAdditions, extras)
        {
        }
    }
}
