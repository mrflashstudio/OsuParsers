using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuBeatmapParser.Objects.Standard
{
    public abstract class StandardHitObject : HitObject
    {
        public bool IsNewCombo { get; }

        public StandardHitObject(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound)
        {
            IsNewCombo = isNewCombo;
        }
    }
}
