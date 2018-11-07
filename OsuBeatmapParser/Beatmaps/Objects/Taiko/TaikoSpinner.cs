using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps.Objects.Taiko
{
    public class TaikoSpinner : TaikoHitObject
    {
        public TaikoSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {

        }
    }
}
