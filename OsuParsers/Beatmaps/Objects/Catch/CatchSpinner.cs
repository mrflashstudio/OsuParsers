using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public class CatchSpinner : CatchHitObject
    {
        public CatchSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, false, 0, extras)
        {
        }
    }
}
