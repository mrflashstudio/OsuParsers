using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoSpinner : TaikoHitObject
    {
        public TaikoSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {

        }
    }
}
