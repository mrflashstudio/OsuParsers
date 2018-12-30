using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoSpinner : Spinner
    {
        public TaikoSpinner(Point position, int startTime, HitSoundType hitSound, Extras extras, int endTime) 
            : base(position, startTime, hitSound, extras, endTime)
        {
        }
    }
}
