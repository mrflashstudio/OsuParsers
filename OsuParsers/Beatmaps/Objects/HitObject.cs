using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects
{
    public abstract class HitObject
    {
        public Point Position { get; }
        public int StartTime { get; }
        public int EndTime { get; }
        public HitSoundType HitSound { get; }
        public HitObjectExtras Extras { get; }
        public int MaxCombo { get; } = 1;

        public HitObject(Point position, int startTime, int endTime, HitSoundType hitSound, HitObjectExtras extras)
        {
            Position = position;
            StartTime = startTime;
            EndTime = endTime;
            HitSound = hitSound;
            Extras = extras;
        }
    }
}
