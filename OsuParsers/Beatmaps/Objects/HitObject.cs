using OsuParsers.Enums;
using System.Drawing;

namespace OsuParsers.Beatmaps.Objects
{
    public class HitObject
    {
        public Point Position { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public HitSoundType HitSound { get; set; }
        public Extras Extras { get; set; }
        public bool IsNewCombo { get; set; }
        public int MaxCombo { get; } = 1;

        public HitObject(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras)
        {
            Position = position;
            StartTime = startTime;
            EndTime = endTime;
            HitSound = hitSound;
            Extras = extras;
        }
    }
}
