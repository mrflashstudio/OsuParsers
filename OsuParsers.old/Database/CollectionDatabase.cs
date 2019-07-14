using OsuParsers.Database.Objects;
using OsuParsers.Writers;
using System.Collections.Generic;

namespace OsuParsers.Database
{
    public class CollectionDatabase
    {
        public int OsuVersion { get; set; }
        public int CollectionCount { get; set; }
        public List<Collection> Collections { get; private set; } = new List<Collection>();

        public void Write(string path)
        {
            DatabaseWriter.WriteCollectionDatabase(path, this);
        }
    }
}
