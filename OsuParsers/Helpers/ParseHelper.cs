using OsuParsers.Enums.Beatmaps;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static Color ParseColour(string line)
        {
            string[] tokens = line.Split(':');
            int[] colour = tokens[1].Trim().Split(',').Select(c => Convert.ToInt32(c)).ToArray();
            return Color.FromArgb(colour.Length == 4 ? colour[3] : 255, colour[0], colour[1], colour[2]);
        }

        public static bool IsLineValid(string line, Sections currentSection)
        {
            switch (currentSection)
            {
                case Sections.Format:
                    return line.ToLower().Contains("osu file format v");
                case Sections.General:
                case Sections.Editor:
                case Sections.Metadata:
                case Sections.Difficulty:
                case Sections.Colours:
                    return line.Contains(":");
                case Sections.Events:
                case Sections.TimingPoints:
                case Sections.HitObjects:
                    return line.Contains(",");
                default: return false;
            }
        }

        public static bool ToBool(this string value) => value == "1" || value.ToLower() == "true";
        public static float ToFloat(this string value) => float.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        public static double ToDouble(this string value) => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
    }
}
