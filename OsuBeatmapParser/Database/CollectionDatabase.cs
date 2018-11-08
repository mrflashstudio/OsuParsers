using OsuBeatmapParser.Database.Objects;
using System.Collections.Generic;

namespace OsuBeatmapParser.Database
{
    public class CollectionDatabase
    {
        public int OsuVersion { get; set; }
        public int CollectionCount { get; set; }
        public List<Collection> Collections { get; private set; } = new List<Collection>();
    }
}
