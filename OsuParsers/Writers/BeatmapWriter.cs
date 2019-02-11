using System.Collections.Generic;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Helpers;
using System.Drawing;

namespace OsuParsers.Writers
{
    internal class BeatmapWriter
    {
        public static List<string> Write(Beatmap beatmap)
        {
            var Sections = new List<List<string>>
            {
                GeneralSection(beatmap.GeneralSection),
                EditorSection(beatmap.EditorSection),
                MetadataSection(beatmap.MetadataSection),
                DifficultySection(beatmap.DifficultySection),
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

        #region Sections

        public static List<string> GeneralSection(GeneralSection section)
        {
            var list = BaseListFormat("General");
            list.AddRange(new List<string>
            {
                "AudioFilename: " + section.AudioFilename,
                "AudioLeadIn: " + section.AudioLeadIn,
                "PreviewTime: " + section.PreviewTime,
                "Countdown: " + section.Countdown.Format(),
                "SampleSet: " + section.SampleSet,
                "StackLeniency: " + section.StackLeniency.Format(),
                "Mode: " + (int)section.Mode,
                "LetterboxInBreaks: " + section.LetterboxInBreaks.Format()
            });

            if (section.StoryFireInFront)
                list.Add("StoryFireInFront: " + section.StoryFireInFront.Format());
            if (section.UseSkinSprites)
                list.Add("UseSkinSprites: " + section.UseSkinSprites.Format());
            if (section.EpilepsyWarning)
                list.Add("EpilepsyWarning: " + section.EpilepsyWarning.Format());
            if (section.Mode == Enums.Ruleset.Mania)
                list.Add("SpecialStyle: " + section.SpecialStyle.Format());

            list.Add("WidescreenStoryboard: " + section.WidescreenStoryboard.Format());

            return list;
        }

        public static List<string> EditorSection(EditorSection section)
        {
            var list = BaseListFormat("Editor");
            if (section.Bookmarks != null)
                list.Add("Bookmarks: " + section.BookmarksString);

            list.AddRange(new List<string>
            {
                "DistanceSpacing: " + section.DistanceSpacing.Format(),
                "BeatDivisor: " + section.BeatDivisor.Format(),
                "GridSize: " + section.GridSize.Format(),
                "TimelineZoom: " + section.TimelineZoom.Format(),
            });

            return list;
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

        public static List<string> DifficultySection(DifficultySection section)
        {
            return new List<string>
            {
                string.Empty,
                "[Difficulty]",
                "HPDrainRate:" + section.HPDrainRate.Format(),
                "CircleSize:" + section.CircleSize.Format(),
                "OverallDifficulty:" + section.OverallDifficulty.Format(),
                "ApproachRate:" + section.ApproachRate.Format(),
                "SliderMultiplier:" + section.SliderMultiplier.Format(),
                "SliderTickRate:" + section.SliderTickRate.Format()
            };
        }

        public static List<string> EventsSection(EventsSection section)
        {
            var list = BaseListFormat("Events");
            list.AddRange(new List<string>
            {
                @"//Background and Video events",
                $"0,0,\"{section.BackgroundImage ?? ""}\",0,0",
            });

            if (section.Video != null)
                list.Add($"1,{section.VideoOffset},{section.Video}");

            list.Add(@"//Break Periods");
            if (section.Breaks.Count > 0)
                list.AddRange(section.Breaks.ConvertAll(b => $"2,{b.StartTime},{b.EndTime}"));

            list.Add(@"//Storyboard Layer 0 (Background)");
            section.Storyboard.BackgroundLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Background)));
            list.Add(@"//Storyboard Layer 1 (Fail)");
            section.Storyboard.FailLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Fail)));
            list.Add(@"//Storyboard Layer 2 (Pass)");
            section.Storyboard.PassLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Pass)));
            list.Add(@"//Storyboard Layer 3 (Foreground)");
            section.Storyboard.ForegroundLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Foreground)));
            list.Add(@"//Storyboard Sound Samples");
            section.Storyboard.SamplesLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, (sbObject as Storyboards.Objects.StoryboardSample).Layer)));

            return list;
        }

        public static List<string> TimingPoints(List<TimingPoint> timingPoints)
        {
            if (timingPoints.Count == 0)
                return new List<string>();

            var list = BaseListFormat("TimingPoints");
            if (timingPoints != null)
                list.AddRange(timingPoints.ConvertAll(point => FormatHelper.TimingPoint(point)));
            list.Add(string.Empty); //osu!stable adds an extra blank line after timing points.
            return list;
        }

        public static List<string> Colours(List<Color> colours)
        {
            if (colours.Count == 0)
                return new List<string>();

            var list = BaseListFormat("Colours");
            if (colours != null)
                for (int i = 0; i < colours.Count; i++)
                    list.Add(FormatHelper.Colour(colours[i], i + 1));
            return list;
        }

        public static List<string> HitObjects(List<HitObject> hitObjects)
        {
            var list = BaseListFormat("HitObjects");
            if (hitObjects != null)
                list.AddRange(hitObjects.ConvertAll(obj => FormatHelper.HitObject(obj)));
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
