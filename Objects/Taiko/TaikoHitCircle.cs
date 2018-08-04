using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public class TaikoHitCircle : TaikoHitObject
    {
        public TaikoColor Color { get; }
        public bool IsBig { get; }

        public TaikoHitCircle(Point position, int startTime, int endTime, int hitSound, TaikoColor color, bool isBig)
            : base(position, startTime, endTime, hitSound)
        {
            Color = color;
            IsBig = isBig;
        }
    }
}
