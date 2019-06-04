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

        public static bool ToBool(string value)
        {
            return value == "1" || value.ToLower() == "true";
        }

        public static float ToFloat(string value)
        {
            if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                return result;
            else
                throw new InvalidCastException(); //could replace with a default value
        }

        public static double ToDouble(string value)
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                return result;
            else
                throw new InvalidCastException(); //could replace with a default value
        }
    }
}
