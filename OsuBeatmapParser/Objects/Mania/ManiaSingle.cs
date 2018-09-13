using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Mania
{
    public class ManiaSingle : ManiaHitObject
    {
        public ManiaSingle(Point position, int startTime, int endTime, HitSoundType hitSound, int collumn)
            : base(position, startTime, endTime, hitSound, collumn)
        {

        }
    }
}
