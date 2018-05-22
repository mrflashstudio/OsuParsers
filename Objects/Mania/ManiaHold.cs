using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuBeatmapParser.Objects.Mania
{
    public class ManiaHold : ManiaHitObject
    {
        public ManiaHold(Point position, int startTime, int endTime, int hitSound, int collumn)
            : base(position, startTime, endTime, hitSound, collumn)
        {

        }
    }
}
