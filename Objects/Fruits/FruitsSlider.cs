using System.Drawing;

namespace OsuBeatmapParser.Objects.Fruits
{
    public class FruitsSlider : FruitsHitObject
    {
        public FruitsSlider(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
