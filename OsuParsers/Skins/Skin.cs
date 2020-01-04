using OsuParsers.Skins.Sections;
using System.IO;

namespace OsuParsers.Skins
{
    public class Skin
    {
        public const double LATEST_VERSION = 2.7;

        public SkinGeneralSection GeneralSection { get; set; }
        public SkinColoursSection ColoursSection { get; set; }
        public SkinFontsSection FontsSection { get; set; }
        public SkinCatchTheBeatSection CatchTheBeatSection { get; set; }
        //public List<SkinManiaSection> ManiaSections { get; set; }

        public Skin()
        {
            GeneralSection = new SkinGeneralSection();
            ColoursSection = new SkinColoursSection();
            FontsSection = new SkinFontsSection();
            CatchTheBeatSection = new SkinCatchTheBeatSection();
            //ManiaSections = new List<SkinManiaSection>();
        }

        /// <summary>
        /// Writes this <see cref="Skin"/> to the specified path.
        /// </summary>
        public void Write(string path)
        {
            File.WriteAllLines(path, Writers.SkinWriter.Write(this));
        }
    }
}
