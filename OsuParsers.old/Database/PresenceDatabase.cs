using OsuParsers.Database.Objects;
using OsuParsers.Writers;
using System.Collections.Generic;

namespace OsuParsers.Database
{
    public class PresenceDatabase
    {
        public int OsuVersion { get; set; }
        public List<Player> Players { get; private set; } = new List<Player>();

        public void Write(string path)
        {
            DatabaseWriter.WritePresenceDatabase(path, this);
        }
    }
}
