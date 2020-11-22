using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace OsuParsers.Encoders
{
    internal class BeatmapEncoder
    {
        public static List<string> Encode(Beatmap beatmap)
        {
            var Sections = new List<List<string>>
            {
                GeneralSection(beatmap.GeneralSection),
                EditorSection(beatmap.EditorSection),
                MetadataSection(beatmap.MetadataSection),
                DifficultySection(beatmap.DifficultySection),
                EventsSection(beatmap.EventsSection),
                TimingPoints(beatmap.TimingPoints),
                Colours(beatmap.ColoursSection),
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

        public static List<string> GeneralSection(BeatmapGeneralSection section)
        {
            var list = WriteHelper.BaseListFormat("General");
            list.AddRange(new List<string>
            {
                "AudioFilename: " + section.AudioFilename,
                "AudioLeadIn: " + section.AudioLeadIn,
                "PreviewTime: " + section.PreviewTime,
                "Countdown: " + section.Countdown.ToInt32(),
                "SampleSet: " + section.SampleSet,
                "StackLeniency: " + section.StackLeniency.Format(),
                "Mode: " + (int)section.Mode,
                "LetterboxInBreaks: " + section.LetterboxInBreaks.ToInt32()
            });

            if (section.StoryFireInFront)
                list.Add("StoryFireInFront: " + section.StoryFireInFront.ToInt32());
            if (section.UseSkinSprites)
                list.Add("UseSkinSprites: " + section.UseSkinSprites.ToInt32());
            if (section.EpilepsyWarning)
                list.Add("EpilepsyWarning: " + section.EpilepsyWarning.ToInt32());
            if (section.Mode == Enums.Ruleset.Mania)
                list.Add("SpecialStyle: " + section.SpecialStyle.ToInt32());

            list.Add("WidescreenStoryboard: " + section.WidescreenStoryboard.ToInt32());

            return list;
        }

        public static List<string> EditorSection(BeatmapEditorSection section)
        {
            var list = WriteHelper.BaseListFormat("Editor");
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

        public static List<string> MetadataSection(BeatmapMetadataSection section)
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

        public static List<string> DifficultySection(BeatmapDifficultySection section)
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

        public static List<string> EventsSection(BeatmapEventsSection section)
        {
            var list = WriteHelper.BaseListFormat("Events");
            list.AddRange(new List<string>
            {
                @"//Background and Video events",
                $"0,0,\"{section.BackgroundImage}\",0,0",
            });

            if (section.Video != null)
                list.Add($"Video,{section.VideoOffset},\"{section.Video}\"");

            list.Add(@"//Break Periods");
            if (section.Breaks.Any())
                list.AddRange(section.Breaks.ConvertAll(b => $"2,{b.StartTime},{b.EndTime}"));

            list.Add(@"//Storyboard Layer 0 (Background)");
            section.Storyboard.BackgroundLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background)));
            list.Add(@"//Storyboard Layer 1 (Fail)");
            section.Storyboard.FailLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail)));
            list.Add(@"//Storyboard Layer 2 (Pass)");
            section.Storyboard.PassLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass)));
            list.Add(@"//Storyboard Layer 3 (Foreground)");
            section.Storyboard.ForegroundLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground)));
            list.Add(@"//Storyboard Layer 4 (Overlay)");
            section.Storyboard.OverlayLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay)));
            list.Add(@"//Storyboard Sound Samples");
            section.Storyboard.SamplesLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as Storyboards.Objects.StoryboardSample).Layer)));

            return list;
        }

        public static List<string> TimingPoints(List<TimingPoint> timingPoints)
        {
            if (timingPoints.Count == 0)
                return new List<string>();

            var list = WriteHelper.BaseListFormat("TimingPoints");
            if (timingPoints != null)
                list.AddRange(timingPoints.ConvertAll(point => WriteHelper.TimingPoint(point)));
            list.Add(string.Empty); //osu!stable adds an extra blank line after timing points.

            return list;
        }

        public static List<string> Colours(BeatmapColoursSection section)
        {
            if (section.ComboColours.Count == 0 && section.SliderTrackOverride == default && section.SliderBorder == default)
                return new List<string>();

            var list = WriteHelper.BaseListFormat("Colours");
            if (section.ComboColours != null)
                for (int i = 0; i < section.ComboColours.Count; i++)
                    list.Add($"Combo{i + 1} : {WriteHelper.Colour(section.ComboColours[i])}");

            if (section.SliderTrackOverride != default)
                list.Add($"SliderTrackOverride : {WriteHelper.Colour(section.SliderTrackOverride)}");

            if (section.SliderBorder != default)
                list.Add($"SliderBorder : {WriteHelper.Colour(section.SliderBorder)}");

            return list;
        }

        public static List<string> HitObjects(List<HitObject> hitObjects)
        {
            var list = WriteHelper.BaseListFormat("HitObjects");
            if (hitObjects != null)
                list.AddRange(hitObjects.ConvertAll(obj => WriteHelper.HitObject(obj)));
            return list;
        }

        #endregion
    }
}
