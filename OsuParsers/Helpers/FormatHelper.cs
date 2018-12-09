using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuParsers.Helpers
{
    public class FormatHelper
    {
        public static string Join(IEnumerable<string> vs, string splitter = " ")
        {
            string owo = string.Empty;
            vs.ToList().ForEach(e => owo += e + splitter);
            return owo;
        }

        public static string Join(IEnumerable<int> vs, string splitter = " ")
        {
            List<string> x = vs.ToList().ConvertAll(e => e.ToString());
            return Join(x, splitter);
        }
    }
}
