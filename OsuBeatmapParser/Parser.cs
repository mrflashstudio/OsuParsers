using OsuBeatmapParser.Beatmaps;
using OsuBeatmapParser.Database;
using OsuBeatmapParser.Decoders;
using OsuBeatmapParser.Storyboards;
using System.IO;

namespace OsuBeatmapParser
{
    public class Parser
    {
        private static StoryboardDecoder storyboardDecoder = new StoryboardDecoder();
        private static BeatmapDecoder beatmapDecoder = new BeatmapDecoder();
        private static DatabaseDecoder databaseDecoder = new DatabaseDecoder();

        /// <summary>
        /// Parses .osu file.
        /// </summary>
        /// <param name="pathToBeatmap">Path to the .osu file.</param>
        /// <returns>A usable beatmap.</returns>
        public static Beatmap ParseBeatmap(string pathToBeatmap) => beatmapDecoder.Decode(File.ReadAllLines(pathToBeatmap));

        /// <summary>
        /// Parses .osb file.
        /// </summary>
        /// <param name="pathToStoryboard">Path to the .osb file.</param>
        /// <returns>A usable storyboard.</returns>
        public static Storyboard ParseStoryboard(string pathToStoryboard) => storyboardDecoder.Decode(File.ReadAllLines(pathToStoryboard));

        /// <summary>
        /// Parses osu!.db file.
        /// </summary>
        /// <param name="pathToOsuDb">Path to the osu!.db file.</param>
        /// <returns>A usable <see cref="OsuDatabase"/>.</returns>
        public static OsuDatabase ParseOsuDatabase(string pathToOsuDb) => databaseDecoder.DecodeOsu(File.OpenRead(pathToOsuDb));

        /// <summary>
        /// Parses collection.db file.
        /// </summary>
        /// <param name="pathToCollectionDb">Path to the collection.db file.</param>
        /// <returns>A usable <see cref="CollectionDatabase"/>.</returns>
        public static CollectionDatabase ParseCollectionDatabase(string pathToCollectionDb) => databaseDecoder.DecodeCollection(File.OpenRead(pathToCollectionDb));

        /// <summary>
        /// Parses scores.db file.
        /// </summary>
        /// <param name="pathToScoresDb">Path to the scores.db file.</param>
        /// <returns>A usable <see cref="ScoresDatabase"/>.</returns>
        public static ScoresDatabase ParseScoresDatabase(string pathToScoresDb) => databaseDecoder.DecodeScores(File.OpenRead(pathToScoresDb));

        /// <summary>
        /// Parses presence.db file.
        /// </summary>
        /// <param name="pathToPresenceDb">Path to the presence.db file.</param>
        /// <returns>A usable <see cref="PresenceDatabase"/>.</returns>
        public static PresenceDatabase ParsePresenceDatabase(string pathToPresenceDb) => databaseDecoder.DecodePresence(File.OpenRead(pathToPresenceDb));
    }
}
