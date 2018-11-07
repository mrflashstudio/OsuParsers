using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Beatmaps.Objects.Standard
{
    public class StandardSpinner : StandardHitObject
    {
        public StandardSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, isNewCombo, extras)
        {
        }
    }
}
