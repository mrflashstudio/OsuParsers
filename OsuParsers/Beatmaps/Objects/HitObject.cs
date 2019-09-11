using OsuParsers.Enums.Beatmaps;
using System;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects
{
    public class HitObject
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public int StartTime { get; set; } = 0;
        public int EndTime { get; set; } = 0;
        public HitSoundType HitSound { get; set; } = 0;
        public Extras Extras { get; set; } = new Extras();
        public bool IsNewCombo { get; set; } = false;
        public int ComboOffset { get; set; } = 0;

        public HitObject() { }
        public HitObject(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset)
        {
            Position = position;
            StartTime = startTime;
            EndTime = endTime;
            HitSound = hitSound;
            Extras = extras;
            IsNewCombo = isNewCombo;
            ComboOffset = comboOffset;
        }

        public TimeSpan StartTimeSpan => TimeSpan.FromMilliseconds(StartTime);
        public TimeSpan EndTimeSpan => TimeSpan.FromMilliseconds(EndTime);
        public TimeSpan TotalTimeSpan => TimeSpan.FromMilliseconds(EndTime - StartTime);

        public float DistanceFrom(HitObject otherObject) => Vector2.Distance(Position, otherObject.Position);
    }
}
