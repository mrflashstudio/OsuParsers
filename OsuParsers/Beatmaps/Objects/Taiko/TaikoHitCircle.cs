using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoHitCircle : TaikoHitObject
    {
        public TaikoColor Color { get; }
        public bool IsBig { get; }

        public TaikoHitCircle(Point position, int startTime, int endTime, HitSoundType hitSound, TaikoColor color, bool isBig, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            Color = color;
            IsBig = isBig;
        }
    }
}
