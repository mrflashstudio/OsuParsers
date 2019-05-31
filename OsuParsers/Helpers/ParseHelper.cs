using OsuParsers.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace OsuParsers.Helpers
{
    internal class ParseHelper
    {
        public static Enums.Sections GetCurrentSection(string line)
        {
            Enums.Sections parsedSection = Enums.Sections.None;
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
                    sliderPoints.Add(new Vector2((int)Convert.ToDouble(positionTokens[0], CultureInfo.InvariantCulture), (int)Convert.ToDouble(positionTokens[1], CultureInfo.InvariantCulture)));
                }
            }

            return sliderPoints;
        }

        public static bool ToBool(string value)
        {
            return (value == "1" || value.ToLower() == "true");
        }

        public static float ToFloat(string value)
        {
            float parsedFloat = 0;
            float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedFloat);
            return parsedFloat;
        }

        public static double ToDouble(string value)
        {
            double parsedDouble = 0;
            double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedDouble);
            return parsedDouble;
        }
    }
}
