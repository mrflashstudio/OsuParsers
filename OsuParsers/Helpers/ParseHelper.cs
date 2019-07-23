using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace OsuParsers.Helpers
{
    internal static class ParseHelper
    {
        public static Sections GetCurrentSection(string line)
        {
            Sections parsedSection = Sections.None;
            Enum.TryParse(line.Trim(new char[] { '[', ']' }), true, out parsedSection);
            return parsedSection;
        }

        public static CurveType GetCurveType(char c)
        {
            switch (c)
            {
                case 'C':
                    return CurveType.Catmull;
                case 'B':
                    return CurveType.Bezier;
                case 'L':
                    return CurveType.Linear;
                case 'P':
                    return CurveType.PerfectCurve;
                default:
                    return CurveType.PerfectCurve;
            }
        }

        public static List<Vector2> GetSliderPoints(string[] segments)
        {
            List<Vector2> sliderPoints = new List<Vector2>();
            foreach (string segmentPos in segments.Skip(1))
            {
                string[] positionTokens = segmentPos.Split(':');
                if (positionTokens.Length == 2)
                {
                    var x = Convert.ToInt32(positionTokens[0], CultureInfo.InvariantCulture);
                    var y = Convert.ToInt32(positionTokens[1], CultureInfo.InvariantCulture);
                    sliderPoints.Add(new Vector2(x, y));
                }
            }
            return sliderPoints;
        }

        public static bool ToBool(this string value) => value == "1" || value.ToLower() == "true";
        public static float ToFloat(this string value) => float.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        public static double ToDouble(this string value) => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
    }
}
