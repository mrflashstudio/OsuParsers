using OsuParsers.Helpers;
using System.Linq;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapEditorSection
    {
        public int[] Bookmarks { get; set; }
        public string BookmarksString
        {
            get => Bookmarks.Join(',');
            set
            {
                var valueArray = value.Split(',').ToList();
                Bookmarks = valueArray.ConvertAll(e => System.Convert.ToInt32(e)).ToArray();
            }
        }
        public double DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
    }
}
