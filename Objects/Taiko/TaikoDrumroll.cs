using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public class TaikoDrumroll : TaikoHitObject
    {
        public int PixelLength { get; }
        public bool IsBig { get; }

        public TaikoDrumroll(Point position, int startTime, int endTime, HitSoundType hitSound, int pixelLength, bool isBig)
            : base(position, startTime, endTime, hitSound)
        {
            PixelLength = pixelLength;
            IsBig = isBig;
        }
    }
}
