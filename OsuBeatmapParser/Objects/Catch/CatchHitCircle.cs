using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Catch
{
    public class CatchHitCircle : CatchHitObject
    {
        public CatchHitCircle(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
