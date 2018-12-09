using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public abstract class CatchHitObject : HitObject
    {
        public bool IsNewCombo { get; }
        public int ComboOffset { get; }

        public CatchHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            IsNewCombo = isNewCombo;
            ComboOffset = comboOffset;
        }
    }
}
