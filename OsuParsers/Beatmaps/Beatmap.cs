using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Enums;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace OsuParsers.Beatmaps
{
    public class Beatmap
    {
        public int Version { get; set; }
        public GeneralSection GeneralSection { get; set; }
        public EditorSection EditorSection { get; set; }
        public MetadataSection MetadataSection { get; set; }
        public DifficultySection DifficultySection { get; set; }
        public EventsSection EventsSection { get; set; }

        public List<Color> Colours { get; set; } = new List<Color>();
        public List<TimingPoint> TimingPoints { get; set; } = new List<TimingPoint>();
        public List<HitObject> HitObjects { get; set; } = new List<HitObject>();

        public Beatmap()
        {
            GeneralSection = new GeneralSection();
            EditorSection = new EditorSection();
            MetadataSection = new MetadataSection();
            DifficultySection = new DifficultySection();
            EventsSection = new EventsSection();
        }

        public void Write(string path)
        {
            NumberFormatInfo format = new CultureInfo(@"en-US", false).NumberFormat;
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine($@"osu file format v{Version}");
                writer.WriteLine();

                writer.WriteLine(@"[General]");
                writer.WriteLine(@"AudioFilename: " + GeneralSection.AudioFilename);
                writer.WriteLine(@"AudioLeadIn: " + GeneralSection.AudioLeadIn);
                writer.WriteLine(@"PreviewTime: " + GeneralSection.PreviewTime);
                writer.WriteLine(@"Countdown: " + (GeneralSection.Countdown ? @"1" : @"0"));
                writer.WriteLine(@"SampleSet: " + GeneralSection.SampleSet);
                writer.WriteLine(@"StackLeniency: " + GeneralSection.StackLeniency.ToString(format));
                writer.WriteLine(@"Mode: " + (int)GeneralSection.Mode);
                writer.WriteLine(@"LetterboxInBreaks: " + (GeneralSection.LetterboxInBreaks ? @"1" : @"0"));
                writer.WriteLine(@"WidescreenStoryboard: " + (GeneralSection.WidescreenStoryboard ? @"1" : @"0"));
                if (GeneralSection.StoryFireInFront)
                    writer.WriteLine(@"StoryFireInFront: 1");
                if (GeneralSection.Mode == Ruleset.Mania)
                    writer.WriteLine(@"SpecialStyle: " + (GeneralSection.SpecialStyle ? @"1" : @"0"));
                if (GeneralSection.EpilepsyWarning)
                    writer.WriteLine(@"EpilepsyWarning: 1");
                if (GeneralSection.UseSkinSprites)
                    writer.WriteLine(@"UseSkinSprites: 1");
                writer.WriteLine();

                writer.WriteLine(@"[Editor]");

                File.WriteAllText(path, writer.GetStringBuilder().ToString());
            }
        }
    }
}
