using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OsuParsers.Helpers
{
    static class Extensions
    {
        private static NumberFormatInfo NumFormat => new CultureInfo(@"en-US", false).NumberFormat;

        public static int ToInt32(this bool value) => value ? 1 : 0;
        public static string Format(this float value) => value.ToString(NumFormat);
        public static string Format(this double value) => value.ToString(NumFormat);
        public static string Format(this int value) => value.ToString(NumFormat);

        public static string Join(this IEnumerable<string> vs, char splitter = ' ')
        {
            if (vs != null)
            {
                string owo = string.Empty;
                vs.ToList().ForEach(e => owo += e + splitter);
                return owo.TrimEnd(splitter);
            }
            else
                return string.Empty;
        }

        public static string Join(this IEnumerable<int> vs, char splitter = ' ')
        {
            if (vs != null)
            {
                List<string> x = vs.ToList().ConvertAll(e => e.ToString());
                return Join(x, splitter);
            }
            else
                return string.Empty;
        }
    }
}
