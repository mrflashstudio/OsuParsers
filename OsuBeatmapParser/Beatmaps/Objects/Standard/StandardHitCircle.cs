using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps.Objects.Standard
{
    public class StandardHitCircle : StandardHitObject
    {
        public StandardHitCircle(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, isNewCombo, extras)
        {
        }
    }
}
