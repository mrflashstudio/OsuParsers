using System.Linq;

namespace OsuParsers.Beatmaps.Sections
{
    public class EditorSection
    {
        public int[] Bookmarks { get; set; }
        public string BookmarksString
        {
            get => Helpers.FormatHelper.Join(Bookmarks, ',');
            set
            {
                var valueArray = value.Split(',').ToList();
                Bookmarks = valueArray.ConvertAll(e => System.Convert.ToInt32(e)).ToArray();
            }
        }
        public float DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
    }
}
