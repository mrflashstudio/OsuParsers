using OsuBeatmapParser.Database.Objects;
using System;
using System.Collections.Generic;

namespace OsuBeatmapParser.Database
{
    public class ScoresDatabase
    {
        public int OsuVersion { get; set; }
        public List<Tuple<string, List<Score>>> Scores { get; private set; } = new List<Tuple<string, List<Score>>>();
    }
}
