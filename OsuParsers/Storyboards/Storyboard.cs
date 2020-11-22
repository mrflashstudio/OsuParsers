using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Interfaces;
using System.Collections.Generic;
using System.IO;
using OsuParsers.Writers;

namespace OsuParsers.Storyboards
{
    public class Storyboard
    {
        public List<IStoryboardObject> BackgroundLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> FailLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> PassLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> ForegroundLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> OverlayLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> SamplesLayer = new List<IStoryboardObject>();

        public Dictionary<string, string> Variables = new Dictionary<string, string>();

        /// <summary>
        /// Returns specified storyboard layer.
        /// </summary>
        public List<IStoryboardObject> GetLayer(StoryboardLayer layer)
        {
            switch (layer)
            {
                case StoryboardLayer.Background:
                    return BackgroundLayer;
                case StoryboardLayer.Fail:
                    return FailLayer;
                case StoryboardLayer.Pass:
                    return PassLayer;
                case StoryboardLayer.Foreground:
                    return ForegroundLayer;
                case StoryboardLayer.Overlay:
                    return OverlayLayer;
                case StoryboardLayer.Samples:
                    return SamplesLayer;
                default:
                    return BackgroundLayer;
            }
        }

        /// <summary>
        /// Saves this <see cref="Storyboard"/> to the specified path.
        /// </summary>
        public void Save(string path)
        {
            File.WriteAllLines(path, StoryboardEncoder.Encode(this));
        }
    }
}
