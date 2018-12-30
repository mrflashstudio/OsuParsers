using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Catch
{
    public class CatchSpinner : Spinner
    {
        public CatchSpinner(Point position, int startTime, HitSoundType hitSound, Extras extras, int endTime) 
            : base(position, startTime, hitSound, extras, endTime)
        {
        }
    }
}
