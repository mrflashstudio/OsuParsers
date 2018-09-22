using OsuBeatmapParser.Enums;
using System;
using System.Globalization;

namespace OsuBeatmapParser.Helpers
{
    public class ParseHelper
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
    }
}
