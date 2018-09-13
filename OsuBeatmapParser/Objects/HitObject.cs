using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Objects
{
    public abstract class HitObject
    {
        public Point Position { get; }
        public int StartTime { get; }
        public int EndTime { get; }
        public HitSoundType HitSound { get; }
        //public List<int> Addition { get; set; } = new List<int>();
        public int MaxCombo { get; } = 1;

        public HitObject(Point position, int startTime, int endTime, HitSoundType hitSound)
        {
            Position = position;
            StartTime = startTime;
            EndTime = endTime;
            HitSound = hitSound;
        }
    }
}
