using System.Drawing;

namespace OsuBeatmapParser.Objects.Mania
{
    public class ManiaHold : ManiaHitObject
    {
        public ManiaHold(Point position, int startTime, int endTime, int hitSound, int collumn)
            : base(position, startTime, endTime, hitSound, collumn)
        {

        }
    }
}
