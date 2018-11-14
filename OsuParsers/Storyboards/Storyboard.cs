using OsuParsers.Enums;
using OsuParsers.Storyboards.Interfaces;
using System.Collections.Generic;

namespace OsuParsers.Storyboards
{
    public class Storyboard
    {
        public List<IStoryboardObject> BackgroundLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> FailLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> PassLayer = new List<IStoryboardObject>();
        public List<IStoryboardObject> ForegroundLayer = new List<IStoryboardObject>();

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
                default:
                    return BackgroundLayer;
            }
        }
    }
}
