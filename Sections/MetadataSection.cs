using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuBeatmapParser.Sections
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
        public string TagsString { get; set; }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }
    }
}
