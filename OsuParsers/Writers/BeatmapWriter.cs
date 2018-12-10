using System;
using System.Collections.Generic;
using System.Globalization;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Beatmaps.Objects;
using System.Drawing;

namespace OsuParsers.Writers
{
    public class BeatmapWriter
    {
        public static List<string> Write(Beatmap beatmap)
        {
            var Sections = new List<List<string>>
            {
                GeneralSection(beatmap.GeneralSection),
                EditorSection(beatmap.EditorSection),
                MetadataSection(beatmap.MetadataSection),
                EventsSection(beatmap.EventsSection),
                TimingPoints(beatmap.TimingPoints),
                Colours(beatmap.Colours),
                HitObjects(beatmap.HitObjects),
            };

            List<string> contents = new List<string>
            {
                $"osu file format v{beatmap.Version}",
            };
            Sections.ForEach(stringList => stringList.ForEach(item => contents.Add(item)));
            return contents;
        }

        private static NumberFormatInfo NumFormat = new CultureInfo(@"en-US", false).NumberFormat;

        #region Sections

        public static List<string> GeneralSection(GeneralSection section)
        {
            return new List<string>
            {
                string.Empty,
                "[General]",
                "AudioFilename: " + section.AudioFilename,
                "AudioLeadIn: " + section.AudioLeadIn,
                "PreviewTime: " + section.PreviewTime,
                "Countdown: " + Helpers.FormatHelper.Bool(section.Countdown),
                "SampleSet: " + section.SampleSet,
                "StackLeniency: " + section.StackLeniency.ToString(NumFormat),
                "Mode: " + (int)section.Mode,
                "LetterboxInBreaks: " + Helpers.FormatHelper.Bool(section.LetterboxInBreaks),
                "WidescreenStoryboard: " + Helpers.FormatHelper.Bool(section.WidescreenStoryboard),
                "StoryFireInFront: " + Helpers.FormatHelper.Bool(section.StoryFireInFront),
                "SpecialStyle: " + Helpers.FormatHelper.Bool(section.SpecialStyle),
                "EpilepsyWarning: " + Helpers.FormatHelper.Bool(section.EpilepsyWarning),
                "UseSkinSprites: " + Helpers.FormatHelper.Bool(section.UseSkinSprites),
            };
        }

        public static List<string> EditorSection(EditorSection section)
        {
            return new List<string>
            {
                string.Empty,
                "[Editor]",
                "Bookmarks: " + section.BookmarksString,
                "DistanceSpacing: " + section.DistanceSpacing.ToString(NumFormat),
                "BeatDivisor: " + section.BeatDivisor.ToString(NumFormat),
                "GridSize: " + section.GridSize.ToString(NumFormat),
                "TimelineZoom: " + section.TimelineZoom.ToString(NumFormat),
            };
        }

        public static List<string> MetadataSection(MetadataSection section)
        {
            return new List<string>
            {
                string.Empty,
                "[Metadata]",
                "Title:" + section.Title,
                "TitleUnicode:" + section.TitleUnicode,
                "Artist:" + section.Artist,
                "ArtistUnicode:" + section.ArtistUnicode,
                "Creator:" + section.Creator,
                "Version:" + section.Version,
                "Source:" + section.Source,
                "Tags:" + section.TagsString,
                "BeatmapID:" + section.BeatmapID,
                "BeatmapSetID:" + section.BeatmapSetID,
            };
        }

        public static List<string> EventsSection(EventsSection section)
        {
            var list = BaseListFormat("Events");
            list.Add(@"//Background and Video events");
            list.Add($"0,0,\"{section.BackgroundImage}\",0,0");
            if (section.Video != null)
                list.Add($"1,{section.VideoOffset},{section.Video}");

            list.Add(@"//Break Periods");
            if (section.Breaks.Count > 0)
                list.AddRange(section.Breaks.ConvertAll(b => $"2,{b.StartTime},{b.EndTime}"));

            //TODO: add storyboard layers
            list.AddRange(new List<string>
            {
                @"//Storyboard Layer 0 (Background)",
                @"//Storyboard Layer 1 (Fail)",
                @"//Storyboard Layer 2 (Pass)",
                @"//Storyboard Layer 3 (Foreground)",
                @"//Storyboard Sound Samples"
            });

            return list;
        }

        public static List<string> TimingPoints(List<TimingPoint> timingPoints)
        {
            var list = BaseListFormat("TimingPoints");
            if (timingPoints != null)
                list.AddRange(timingPoints.ConvertAll(point => Helpers.FormatHelper.TimingPoint(point)));
            return list;
        }

        public static List<string> Colours(List<Color> colours)
        {
            var list = BaseListFormat("Colours");
            if (colours != null)
                for (int i = 0; i < colours.Count; i++)
                    list.Add(Helpers.FormatHelper.Colour(colours[i], i + 1));
            return list;
        }

        public static List<string> HitObjects(List<HitObject> hitObjects)
        {
            var list = BaseListFormat("HitObjects");
            if (hitObjects != null)
                list.AddRange(hitObjects.ConvertAll(obj => Helpers.FormatHelper.HitObject(obj)));
            return list;
        }

        #endregion

        public static List<string> BaseListFormat(string SectionName)
        {
            return new List<string>
            {
                string.Empty,
                $"[{SectionName}]",
            };
        }
    }
}
