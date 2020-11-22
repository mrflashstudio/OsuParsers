using OsuParsers.Database.Objects;
using System;
using System.Collections.Generic;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
    public class ScoresDatabase
    {
        public int OsuVersion { get; set; }
        public List<Tuple<string, List<Score>>> Scores { get; set; } = new List<Tuple<string, List<Score>>>();

        /// <summary>
        /// Saves this <see cref="ScoresDatabase"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            DatabaseEncoder.EncodeScoresDatabase(path, this);
        }
    }
}
