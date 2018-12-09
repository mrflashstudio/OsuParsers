using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Standard
{
    public class StandardSpinner : StandardHitObject
    {
        public StandardSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, bool isNewCombo, int comboOffset, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, isNewCombo, comboOffset, extras)
        {
        }
    }
}
