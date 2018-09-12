using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public class TaikoSpinner : TaikoHitObject
    {
        public TaikoSpinner(Point position, int startTime, int endTime, HitSoundType hitSound)
            : base(position, startTime, endTime, hitSound)
        {

        }
    }
}
