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
                if (value && !HitSound.HasFlag(HitSoundType.Finish))
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
                {
                    if (HitSound.HasFlag(HitSoundType.Whistle))
                        HitSound -= (int)HitSoundType.Whistle;
                    if (HitSound.HasFlag(HitSoundType.Clap))
                        HitSound -= (int)HitSoundType.Clap;

                    if (!HitSound.HasFlag(HitSoundType.Normal))
                        HitSound += (int)HitSoundType.Normal;
                }
                else if (value == TaikoColor.Blue)
                {
                    if (HitSound.HasFlag(HitSoundType.Normal))
                        HitSound -= (int)HitSoundType.Normal;

                    if (!HitSound.HasFlag(HitSoundType.Whistle))
                        HitSound += (int)HitSoundType.Whistle;
                }
            }
        }

        public TaikoHit(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, endTime, hitSound, extras, false, 0)
        {
        }
    }
}
