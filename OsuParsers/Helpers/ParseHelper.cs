using OsuParsers.Enums;
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
        public static FileSections GetCurrentSection(string line)
        {
            FileSections parsedSection = FileSections.None;
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
            int[] colour = line.Split(',').Select(c => Convert.ToInt32(c)).ToArray();
            return Color.FromArgb(colour.Length == 4 ? colour[3] : 255, colour[0], colour[1], colour[2]);
        }

        public static bool IsLineValid(string line, FileSections currentSection)
        {
            switch (currentSection)
            {
                case FileSections.Format:
                    return line.ToLower().Contains("osu file format v");
                case FileSections.General:
                case FileSections.Editor:
                case FileSections.Metadata:
                case FileSections.Difficulty:
                case FileSections.Fonts:
                case FileSections.Mania:
                    return line.Contains(":");
                case FileSections.Events:
                case FileSections.TimingPoints:
                case FileSections.HitObjects:
                    return line.Contains(",");
                case FileSections.Colours:
                case FileSections.CatchTheBeat:
                    return line.Contains(',') && line.Contains(':');
                default: return false;
            }
        }

        public static bool ToBool(this string value) => value == "1" || value.ToLower() == "true";
        public static float ToFloat(this string value) => float.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        public static double ToDouble(this string value) => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
    }
}
