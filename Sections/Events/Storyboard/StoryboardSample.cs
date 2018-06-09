using OsuBeatmapParser.Enums;
using System.Drawing;

namespace OsuBeatmapParser.Sections.Events.Storyboard
{
    public class StoryboardSample : StoryboardObject
    {
        public int Time { get; private set; }
        public int LayerNumber { get; private set; }
        public StoryboardLayer Layer { get; private set; }
        public string FilePath { get; private set; }
        public int Volume { get; private set; }

        public StoryboardSample(int time, int layerNum, string filePath, int volume)
        {
            Time = time;
            LayerNumber = layerNum;
            switch (layerNum)
            {
                case 0:
                    Layer = StoryboardLayer.Background;
                    break;
                case 1:
                    Layer = StoryboardLayer.Fail;
                    break;
                case 2:
                    Layer = StoryboardLayer.Pass;
                    break;
                case 3:
                    Layer = StoryboardLayer.Foreground;
                    break;
                default:
                    Layer = StoryboardLayer.Background;
                    break;
            }
            FilePath = filePath;
            Volume = volume;
        }
    }
}
