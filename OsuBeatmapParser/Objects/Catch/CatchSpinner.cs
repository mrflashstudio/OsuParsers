using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Catch
{
    public class CatchSpinner : CatchHitObject
    {
        public CatchSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, false, extras)
        {
        }
    }
}
