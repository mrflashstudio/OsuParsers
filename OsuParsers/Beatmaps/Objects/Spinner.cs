using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects
{
    public class Spinner : HitObject
    {
        public Spinner(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) 
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
        }
    }
}
