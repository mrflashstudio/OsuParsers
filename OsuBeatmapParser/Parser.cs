using OsuBeatmapParser.Decoders;
using OsuBeatmapParser.Storyboards;
using System.IO;

namespace OsuBeatmapParser
{
    public class Parser
    {
        private StoryboardDecoder storyboardDecoder = new StoryboardDecoder();
        private BeatmapDecoder beatmapDecoder = new BeatmapDecoder();

        /// <summary>
        /// Parses .osu file.
        /// </summary>
        /// <param name="pathToBeatmap">Path to the .osu file.</param>
        /// <returns>A usable beatmap.</returns>
        public Beatmap ParseBeatmap(string pathToBeatmap) => beatmapDecoder.Decode(File.ReadAllLines(pathToBeatmap));

        /// <summary>
        /// Parses .osb file.
        /// </summary>
        /// <param name="pathToStoryboard">Path to the .osb file.</param>
        /// <returns>A usable storyboard.</returns>
        public Storyboard ParseStoryboard(string pathToStoryboard) => storyboardDecoder.Decode(File.ReadAllLines(pathToStoryboard));
    }
}
