using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Mania
{
    public abstract class ManiaHitObject : HitObject
    {
        public int Collumn { get; }

        public ManiaHitObject(Point position, int startTime, int endTime, int hitSound, int collumn) //TODO: make all calculations inside hitobject's class
            : base(position, startTime, endTime, hitSound)
        {
            Collumn = collumn;
        }
    }
}
