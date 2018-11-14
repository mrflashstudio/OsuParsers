using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public abstract class CatchHitObject : HitObject
    {
        public bool IsNewCombo { get; }

        public CatchHitObject(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            IsNewCombo = isNewCombo;
        }
    }
}
