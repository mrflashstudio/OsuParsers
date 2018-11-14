using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects.Mania
{
    public class ManiaSingle : ManiaHitObject
    {
        public ManiaSingle(Point position, int startTime, int endTime, HitSoundType hitSound, int collumn, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, collumn, extras)
        {

        }
    }
}
