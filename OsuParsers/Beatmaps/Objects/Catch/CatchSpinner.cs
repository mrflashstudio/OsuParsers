using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public class CatchSpinner : Spinner
    {
        public CatchSpinner(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras) 
            : base(position, startTime, endTime, hitSound, extras)
        {
        }
    }
}
