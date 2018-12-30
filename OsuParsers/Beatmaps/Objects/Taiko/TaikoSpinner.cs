using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoSpinner : Spinner
    {
        public TaikoSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
