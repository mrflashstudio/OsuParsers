using System.Drawing;

namespace OsuBeatmapParser.Objects.Fruits
{
    public class Fruit : FruitsHitObject
    {
        public Fruit(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
