using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects
{
    public class Spinner : HitObject
    {
        public Spinner(Point position, int startTime, HitSoundType hitSound, Extras extras, int endTime) 
            : base(position, startTime, hitSound, extras)
        {
            EndTime = endTime;
        }

        public int EndTime { get; set; }
    }
}
