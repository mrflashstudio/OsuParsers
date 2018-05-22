using System.Drawing;

namespace OsuBeatmapParser.Objects.Fruits
{
    public class FruitsBananas : FruitsHitObject
    {
        public FruitsBananas(Point position, int startTime, int endTime, int hitSound)
            : base(position, startTime, endTime, hitSound, false)
        {
        }
    }
}
