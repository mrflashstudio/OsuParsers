using OsuParsers.Database.Objects;
using System.Collections.Generic;
using OsuParsers.Encoders;

namespace OsuParsers.Database
{
    public class PresenceDatabase
    {
        public int OsuVersion { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        /// <summary>
        /// Saves this <see cref="PresenceDatabase"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            DatabaseEncoder.EncodePresenceDatabase(path, this);
        }
    }
}
