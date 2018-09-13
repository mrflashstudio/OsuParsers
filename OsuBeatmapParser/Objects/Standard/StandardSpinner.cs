using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Standard
{
    public class StandardSpinner : StandardHitObject
    {
        public StandardSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
