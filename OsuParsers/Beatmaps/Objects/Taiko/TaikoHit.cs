using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoHit : Circle
    {
        public bool IsBig
        {
            get
            {
                return HitSound.HasFlag(HitSoundType.Finish);
            }
        }
        public TaikoColor Color { get; set; }

        public TaikoHit(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isBig, TaikoColor color) 
            : base(position, startTime, endTime, hitSound, extras, false, 0)
        {
            //IsBig = isBig; (Needs to be finished, commented out to keep some functionality)
            Color = color;
        }
    }
}
