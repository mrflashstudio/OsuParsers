using OsuBeatmapParser.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Mania
{
    public abstract class ManiaHitObject : HitObject
    {
        public int Collumn { get; }

        public ManiaHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, int collumn)
            : base(position, startTime, endTime, hitSound)
        {
            Collumn = collumn;
        }
    }
}
