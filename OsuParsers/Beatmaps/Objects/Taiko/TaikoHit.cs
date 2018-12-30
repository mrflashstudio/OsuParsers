using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoHit : HitObject
    {
        public TaikoHit(Point position, int startTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, hitSound, extras)
        {
        }
    }
}
