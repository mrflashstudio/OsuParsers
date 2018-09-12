using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Standard
{
    public class StandardHitCircle : StandardHitObject
    {
        public StandardHitCircle(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
