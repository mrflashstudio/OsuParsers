using System.Drawing;

namespace OsuBeatmapParser.Objects.Fruits
{
    public abstract class FruitsHitObject : HitObject
    {
        public bool IsNewCombo { get; }

        public FruitsHitObject(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound)
        {
            IsNewCombo = isNewCombo;
        }
    }
}
