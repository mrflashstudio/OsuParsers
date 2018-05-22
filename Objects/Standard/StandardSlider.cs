using OsuBeatmapParser.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Standard
{
    public class StandardSlider : StandardHitObject
    {
        public CurveType CurveType { get; }
        public List<Point> SliderPoints { get; } = new List<Point>();
        public int Repeats { get; }
        public float PixelLength { get; }

        //public int EdgeHitSound { get; set; }
        //public List<int> EdgeAddition { get; set; }

        public StandardSlider(Point position, int startTime, int endTime, int hitSound, bool isNewCombo, CurveType type,
            List<Point> points, int repeats, float pixelLength) : base(position, startTime, endTime, hitSound, isNewCombo)
        {
            CurveType = type;
            SliderPoints = points;
            Repeats = repeats;
            PixelLength = pixelLength;
        }
    }
}
