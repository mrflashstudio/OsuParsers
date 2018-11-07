using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps.Objects.Catch
{
    public class CatchHitCircle : CatchHitObject
    {
        public CatchHitCircle(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, isNewCombo, extras)
        {
        }
    }
}
