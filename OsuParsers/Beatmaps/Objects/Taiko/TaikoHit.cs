using OsuParsers.Enums.Beatmaps;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoHit : HitCircle
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

        public TaikoHit(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset)
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
        }
    }
}
