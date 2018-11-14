using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public abstract class TaikoHitObject : HitObject
    {
        public TaikoHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
