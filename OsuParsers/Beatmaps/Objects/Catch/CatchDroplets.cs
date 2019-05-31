using System;
using System.Collections.Generic;
using System.Numerics;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public class CatchDroplets : Slider
    {
        public CatchDroplets(Vector2 position, int startTime, int endTime, HitSoundType hitSound, CurveType type, 
            List<Vector2> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds,
            List<Tuple<SampleSet, SampleSet>> edgeAdditions, Extras extras, bool isNewCombo, int comboOffset) 
            : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, edgeHitSounds, edgeAdditions, extras, isNewCombo, comboOffset)
        {
        }
    }
}
