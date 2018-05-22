using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public abstract class TaikoHitObject : HitObject
    {
        public TaikoHitObject(Point position, int startTime, int endTime, int hitSound)
            : base(position, startTime, endTime, hitSound)
        {
        }
    }
}
