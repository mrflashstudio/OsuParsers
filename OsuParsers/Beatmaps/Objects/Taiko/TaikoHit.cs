using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoHit : HitObject
    {
        public TaikoHit(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
