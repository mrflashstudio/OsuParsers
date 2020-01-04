using OsuParsers.Helpers;

namespace OsuParsers.Beatmaps.Sections
{
    public class BeatmapMetadataSection
    {
        public string Title { get; set; }
        public string TitleUnicode { get; set; }
        public string Artist { get; set; }
        public string ArtistUnicode { get; set; }
        public string Creator { get; set; }
        public string Version { get; set; }
        public string Source { get; set; }
        public string[] Tags { get; set; }
        public string TagsString
        {
            get => Tags.Join();
            set => Tags = value.Split(' ');
        }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }
    }
}
