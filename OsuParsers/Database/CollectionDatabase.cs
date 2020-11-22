using OsuParsers.Database.Objects;
using System.Collections.Generic;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
    public class CollectionDatabase
    {
        public int OsuVersion { get; set; }
        public int CollectionCount { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();

        /// <summary>
        /// Saves this <see cref="CollectionDatabase"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            DatabaseEncoder.EncodeCollectionDatabase(path, this);
        }
    }
}
