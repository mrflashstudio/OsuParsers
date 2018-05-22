using OsuBeatmapParser.Enums;
using OsuBeatmapParser.Objects;
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

        public static Ruleset GetRulesetFromId(int id)
        {
            switch (id)
            {
                case 0:
                    return Ruleset.Standard;
                case 1:
                    return Ruleset.Taiko;
                case 2:
                    return Ruleset.Fruits;
                case 3:
                    return Ruleset.Mania;
                default:
                    throw new Exception("Unknown ruleset id!");
            }
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

        public static HitSoundType GetHitSoundTypeFromId(int id)
        {
            switch (id)
            {
                case 0:
                    return HitSoundType.Normal;
                case 2:
                    return HitSoundType.Whistle;
                case 4:
                    return HitSoundType.Finish;
                case 8:
                    return HitSoundType.Clap;
                default:
                    throw new Exception("Unknown hitsound id!");
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
