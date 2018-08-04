using System.Drawing;

namespace OsuBeatmapParser.Objects.Catch
{
    public class CatchSlider : CatchHitObject
    {
        public CatchSlider(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
