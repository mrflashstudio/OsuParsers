using OsuParsers.Enums;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects
{
    public class HitObject
    {
        public Vector2 Position { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public HitSoundType HitSound { get; set; }
        public Extras Extras { get; set; }
        public bool IsNewCombo { get; set; }
        public int ComboOffset { get; set; }
        public int MaxCombo { get; } = 1;

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
    }
}
