using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuBeatmapParser.Objects.Standard
{
    public class StandardHitCircle : StandardHitObject
    {
        public StandardHitCircle(Point position, int startTime, int endTime, int hitSound, bool isNewCombo)
            : base(position, startTime, endTime, hitSound, isNewCombo)
        {
        }
    }
}
