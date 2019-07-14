using OsuParsers.Enums;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects
{
    public class Circle : HitObject
    {
        public Circle(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) 
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
        }
    }
}
