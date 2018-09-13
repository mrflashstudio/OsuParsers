namespace OsuBeatmapParser.Sections
{
    public class EditorSection
    {
        public int[] Bookmarks { get; set; }
        public string BookmarksString { get; set; }
        public float DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
    }
}
