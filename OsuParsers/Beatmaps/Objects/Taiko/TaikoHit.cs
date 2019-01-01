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
            set
            {
                if (value)
                    HitSound += (int)HitSoundType.Finish;
                else
                    if (HitSound.HasFlag(HitSoundType.Finish))
                        HitSound -= (int)HitSoundType.Finish;
            }
        }
        public TaikoColor Color
        {
            get
            {
                if (HitSound.HasFlag(HitSoundType.Whistle) || HitSound.HasFlag(HitSoundType.Clap))
                    return TaikoColor.Blue;
                else
                    return TaikoColor.Red;
            }
            set
            {
                if (value == TaikoColor.Red)
                    HitSound = HitSoundType.Normal;
                else if (value == TaikoColor.Blue)
                    HitSound = HitSoundType.Whistle;
            }
        }

        public TaikoHit(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isBig, TaikoColor color) 
            : base(position, startTime, endTime, hitSound, extras, false, 0)
        {
            // These may be unnecessary now
            IsBig = isBig;
            Color = color;
        }
    }
}
