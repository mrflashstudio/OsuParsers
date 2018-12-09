using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Standard
{
    public abstract class StandardHitObject : HitObject
    {
        public bool IsNewCombo { get; }
        public int ComboOffset { get; }

        public StandardHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            IsNewCombo = isNewCombo;
            ComboOffset = comboOffset;
        }
    }
}
