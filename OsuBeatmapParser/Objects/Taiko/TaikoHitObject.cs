using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public abstract class TaikoHitObject : HitObject
    {
        public TaikoHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
