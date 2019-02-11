using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace OsuParsers.Test.Helpers
{
    public class CompareHelper
    {
        public static bool CompareWithJsonFormat<T>(T self, T to) where T : class
        {
            var selfString = JsonConvert.SerializeObject(self);
            var toString = JsonConvert.SerializeObject(to);

            return selfString == toString;
        }
    }
}
