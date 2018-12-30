using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects
{
    class Circle : HitObject
    {
        public Circle(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
