namespace OsuParsers.Beatmaps.Sections
{
    public class MetadataSection
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
            get => Helpers.FormatHelper.Join(Tags);
            set => Tags = value.Split(' ');
        }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }
    }
}
