using System;
using System.Collections.Generic;
using System.IO;

namespace OsuParsers.Tests
{
    public static class Extensions
    {
        public static IEnumerable<string> ReadAllLines(this Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var full = sr.ReadToEnd();
                return full.Split(new string[] { Environment.NewLine }, 0);
            }
        }
    }
}
