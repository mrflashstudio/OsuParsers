using OsuParsers.Database.Objects;
using System;
using System.Collections.Generic;

namespace OsuParsers.Database
{
    public class ScoresDatabase
    {
        public int OsuVersion { get; set; }
        public List<Tuple<string, List<Score>>> Scores { get; private set; } = new List<Tuple<string, List<Score>>>();
    }
}
