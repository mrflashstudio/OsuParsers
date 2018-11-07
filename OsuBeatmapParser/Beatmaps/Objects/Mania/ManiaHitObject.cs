using OsuBeatmapParser.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps.Objects.Mania
{
    public abstract class ManiaHitObject : HitObject
    {
        public int Collumn { get; }

        public ManiaHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, int collumn, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            Collumn = collumn;
        }
    }
}
