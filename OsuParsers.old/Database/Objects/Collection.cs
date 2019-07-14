using System.Collections.Generic;

namespace OsuParsers.Database.Objects
{
    public class Collection
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<string> MD5Hashes { get; private set; } = new List<string>();
    }
}
