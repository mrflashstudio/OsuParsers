using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Mania
{
    class ManiaHold : ManiaHit
    {
        public ManiaHold(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, hitSound, extras)
        {
            EndTime = endTime;
        }

        public int EndTime { set; get; }
    }
}
