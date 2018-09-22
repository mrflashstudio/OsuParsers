using OsuBeatmapParser.Enums;
using OsuBeatmapParser.Helpers;
using OsuBeatmapParser.Objects;
using OsuBeatmapParser.Objects.Catch;
using OsuBeatmapParser.Objects.Mania;
using OsuBeatmapParser.Objects.Standard;
using OsuBeatmapParser.Objects.Taiko;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OsuBeatmapParser
{
    public class Parser
    {
        /// <summary>
        /// Parsed beatmap.
        /// </summary>
        public Beatmap Beatmap { get; private set; }
        private Enums.Sections currentSection = Enums.Sections.None;
        
        /// <summary>
        /// </summary>
        /// <param name="path">Path to the .osu file.</param>
        public Parser(string path)
        {
            Beatmap = new Beatmap();
            currentSection = Enums.Sections.Format;
            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (ParseHelper.GetCurrentSection(line) != Enums.Sections.None)
                        currentSection = ParseHelper.GetCurrentSection(line);
                    else
                        ParseLine(line);
                }
            }

            Beatmap.GeneralSection.CirclesCount = Beatmap.HitObjects.Count(c => c is StandardHitCircle || c is TaikoHitCircle || c is ManiaSingle || c is CatchHitCircle);
            Beatmap.GeneralSection.SlidersCount = Beatmap.HitObjects.Count(c => c is StandardSlider || c is TaikoDrumroll || c is ManiaHold || c is CatchSlider);
            Beatmap.GeneralSection.SpinnersCount = Beatmap.HitObjects.Count(c => c is StandardSpinner || c is TaikoSpinner || c is CatchSpinner);

            Beatmap.GeneralSection.Length = Beatmap.HitObjects.Last().EndTime / 1000;
        }

        private void ParseLine(string line)
        {
            switch (currentSection)
            {
                case Enums.Sections.Format:
                    Beatmap.Version = Convert.ToInt32(line.Split(new string[] { "osu file format v" }, StringSplitOptions.None)[1]);
                    break;
                case Enums.Sections.General:
                    ParseGeneral(line);
                    break;
                case Enums.Sections.Editor:
                    ParseEditor(line);
                    break;
                case Enums.Sections.Metadata:
                    ParseMetadata(line);
                    break;
                case Enums.Sections.Difficulty:
                    ParseDifficulty(line);
                    break;
                case Enums.Sections.Events:
                    ParseEvents(line);
                    break;
                case Enums.Sections.TimingPoints:
                    ParseTimingPoints(line);
                    break;
                case Enums.Sections.Colours:
                    ParseColours(line);
                    break;
                case Enums.Sections.HitObjects:
                    ParseHitObjects(line);
                    break;
            }
        }

        private void ParseGeneral(string line)
        {
            string[] tokens = line.Split(':');
            switch (tokens[0])
            {
                case "AudioFilename":
                    Beatmap.GeneralSection.AudioFilename = tokens[1].Trim();
                    break;
                case "AudioLeadIn":
                    Beatmap.GeneralSection.AudioLeadIn = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "PreviewTime":
                    Beatmap.GeneralSection.PreviewTime = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "Countdown":
                    Beatmap.GeneralSection.Countdown = ParseHelper.ToBool(tokens[1].Trim());
                    break;
                case "SampleSet":
                    Beatmap.GeneralSection.SampleSet = (SampleSet)Enum.Parse(typeof(SampleSet), tokens[1].Trim());
                    break;
                case "StackLeniency":
                    Beatmap.GeneralSection.StackLeniency = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "Mode":
                    Beatmap.GeneralSection.Mode = (Ruleset)Enum.Parse(typeof(Ruleset), tokens[1].Trim());
                    Beatmap.GeneralSection.ModeId = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "LetterboxInBreaks":
                    Beatmap.GeneralSection.LetterboxInBreaks = ParseHelper.ToBool(tokens[1].Trim());
                    break;
                case "WidescreenStoryboard":
                    Beatmap.GeneralSection.WidescreenStoryboard = ParseHelper.ToBool(tokens[1].Trim());
                    break;
            }
        }

        private void ParseEditor(string line)
        {
            string[] tokens = line.Split(':');
            switch (tokens[0])
            {
                case "Bookmarks":
                    Beatmap.EditorSection.Bookmarks = tokens[1].Trim().Split(',').Select(b => Convert.ToInt32(b)).ToArray();
                    Beatmap.EditorSection.BookmarksString = tokens[1].Trim();
                    break;
                case "DistanceSpacing":
                    Beatmap.EditorSection.DistanceSpacing = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "BeatDivisor":
                    Beatmap.EditorSection.BeatDivisor = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "GridSize":
                    Beatmap.EditorSection.GridSize = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "TimelineZoom":
                    Beatmap.EditorSection.TimelineZoom = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
            }
        }

        private void ParseMetadata(string line)
        {
            string[] tokens = line.Split(':');
            switch (tokens[0])
            {
                case "Title":
                    Beatmap.MetadataSection.Title = tokens[1].Trim();
                    break;
                case "TitleUnicode":
                    Beatmap.MetadataSection.TitleUnicode = tokens[1].Trim();
                    break;
                case "Artist":
                    Beatmap.MetadataSection.Artist = tokens[1].Trim();
                    break;
                case "ArtistUnicode":
                    Beatmap.MetadataSection.ArtistUnicode = tokens[1].Trim();
                    break;
                case "Creator":
                    Beatmap.MetadataSection.Creator = tokens[1].Trim();
                    break;
                case "Version":
                    Beatmap.MetadataSection.Version = tokens[1].Trim();
                    break;
                case "Source":
                    Beatmap.MetadataSection.Source = tokens[1].Trim();
                    break;
                case "Tags":
                    Beatmap.MetadataSection.Tags = tokens[1].Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Beatmap.MetadataSection.TagsString = tokens[1].Trim();
                    break;
                case "BeatmapID":
                    Beatmap.MetadataSection.BeatmapID = Convert.ToInt32(tokens[1].Trim());
                    break;
                case "BeatmapSetID":
                    Beatmap.MetadataSection.BeatmapSetID = Convert.ToInt32(tokens[1].Trim());
                    break;
            }
        }

        private void ParseDifficulty(string line)
        {
            string[] tokens = line.Split(':');
            switch (tokens[0])
            {
                case "HPDrainRate":
                    Beatmap.DifficultySection.HPDrainRate = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "CircleSize":
                    Beatmap.DifficultySection.CircleSize = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "OverallDifficulty":
                    Beatmap.DifficultySection.OverallDifficulty = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "ApproachRate":
                    Beatmap.DifficultySection.ApproachRate = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "SliderMultiplier":
                    Beatmap.DifficultySection.SliderMultiplier = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
                case "SliderTickRate":
                    Beatmap.DifficultySection.SliderTickRate = ParseHelper.ToFloat(tokens[1].Trim());
                    break;
            }
        }

        private void ParseEvents(string line)
        {
            //TODO: implement events parser
        }

        private void ParseTimingPoints(string line)
        {
            string[] tokens = line.Split(',');

            int offset = (int)ParseHelper.ToFloat(tokens[0]);
            float beatLength = ParseHelper.ToFloat(tokens[1]);
            TimeSignature timeSignature = TimeSignature.SimpleQuadruple;
            SampleSet sampleSet = SampleSet.None;
            int customSampleSet = 0;
            int volume = 100;
            bool inherited = true;
            bool kiaiMode = false;

            if (tokens.Length >= 3)
                timeSignature = (TimeSignature)Convert.ToInt32(tokens[2]);

            if (tokens.Length >= 4)
                sampleSet = (SampleSet)Convert.ToInt32(tokens[3]);

            if (tokens.Length >= 5)
                customSampleSet = Convert.ToInt32(tokens[4]);

            if (tokens.Length >= 6)
                volume = Convert.ToInt32(tokens[5]);

            if (tokens.Length >= 7)
                inherited = ParseHelper.ToBool(tokens[6]);

            if (tokens.Length >= 8)
                kiaiMode = ParseHelper.ToBool(tokens[7]);

            Beatmap.TimingPoints.Add(new TimingPoint
            {
                Offset = offset,
                BeatLength = beatLength,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = inherited,
                KiaiMode = kiaiMode,
            });
        }

        private void ParseColours(string line)
        {
            string[] tokens = line.Split(':');
            int[] rgb = tokens[1].Trim().Select(c => Convert.ToInt32(c)).ToArray();
            Beatmap.Colours.Add(Color.FromArgb(rgb[0], rgb[1], rgb[2]));
        }

        private void ParseHitObjects(string line)
        {
            string[] tokens = line.Split(',');

            HitObject hitObject = null;

            HitObjectType type = (HitObjectType)int.Parse(tokens[3]) & ~HitObjectType.ColourHax;
            bool isNewCombo = type.HasFlag(HitObjectType.NewCombo);
            type &= ~HitObjectType.NewCombo;
            Point position = new Point(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]));
            int startTime = Convert.ToInt32(tokens[2]);
            HitSoundType hitSound = (HitSoundType)Convert.ToInt32(tokens[4]);

            switch (Beatmap.GeneralSection.Mode)
            {
                case Ruleset.Standard:
                    if (type.HasFlag(HitObjectType.Circle))
                    {
                        hitObject = new StandardHitCircle(position, startTime, startTime, hitSound, isNewCombo);
                    }
                    else if (type.HasFlag(HitObjectType.Slider))
                    {
                        CurveType curveType = ParseHelper.GetCurveType(tokens[5].Split('|')[0][0]);

                        string[] hitSliderSegments = tokens[5].Split('|');
                        List<Point> sliderPoints = new List<Point>();
                        foreach (string hitSliderSegmentPosition in hitSliderSegments.Skip(1))
                        {
                            string[] positionTokens = hitSliderSegmentPosition.Split(':');
                            if (positionTokens.Length == 2)
                            {
                                sliderPoints.Add(new Point((int)Convert.ToDouble(positionTokens[0], CultureInfo.InvariantCulture), (int)Convert.ToDouble(positionTokens[1], CultureInfo.InvariantCulture)));
                            }
                        }

                        int repeats = Convert.ToInt32(tokens[6]);
                        float pixelLength = ParseHelper.ToFloat(tokens[7]);

                        //TODO: Parse additions

                        var timingPoint = GetTimingPointFromOffset(startTime);
                        var parentTimingPoint = timingPoint;
                        double velocity = 1;

                        if (timingPoint.BeatLength < 0)
                        {
                            velocity = Math.Abs(100 / timingPoint.BeatLength);
                            parentTimingPoint = GetParentTimingPoint(timingPoint);
                        }

                        double pixelsPerBeat = Beatmap.DifficultySection.SliderMultiplier * 100 * velocity;
                        double beats = pixelLength * repeats / pixelsPerBeat;
                        int duration = (int)Math.Ceiling(beats * parentTimingPoint.BeatLength);
                        int endTime = startTime + duration;

                        hitObject = new StandardSlider(position, startTime, endTime, hitSound, isNewCombo, curveType, sliderPoints, repeats, pixelLength);
                    }
                    else
                    {
                        int endTime = Convert.ToInt32(tokens[5]);
                        hitObject = new StandardSpinner(position, startTime, endTime, hitSound, isNewCombo);
                    }
                    break;
                case Ruleset.Taiko:
                    bool isBlue = hitSound.HasFlag(HitSoundType.Whistle) || hitSound.HasFlag(HitSoundType.Clap);
                    TaikoColor color = isBlue ? TaikoColor.Blue : TaikoColor.Red;
                    bool isBig = hitSound.HasFlag(HitSoundType.Finish);

                    if (type.HasFlag(HitObjectType.Circle))
                        hitObject = new TaikoHitCircle(position, startTime, startTime, hitSound, color, isBig);
                    else if (type.HasFlag(HitObjectType.Slider))
                    {
                        int repeats = Convert.ToInt32(tokens[6].Trim());
                        float pixelLength = ParseHelper.ToFloat(tokens[7].Trim());
                        hitObject = new TaikoDrumroll(position, startTime, startTime, hitSound, (int)(repeats * pixelLength), isBig);
                    }
                    else
                    {
                        int endTime = Convert.ToInt32(tokens[5].Trim());
                        hitObject = new TaikoSpinner(position, startTime, endTime, hitSound);
                    }
                    break;
                case Ruleset.Fruits:
                    if (type.HasFlag(HitObjectType.Circle))
                        hitObject = new CatchHitCircle(position, startTime, startTime, hitSound, isNewCombo);
                    else if (type.HasFlag(HitObjectType.Slider))
                    {
                        CurveType curveType = ParseHelper.GetCurveType(tokens[5].Split('|')[0][0]);

                        string[] hitSliderSegments = tokens[5].Split('|');
                        List<Point> sliderPoints = new List<Point>();
                        foreach (string hitSliderSegmentPosition in hitSliderSegments.Skip(1))
                        {
                            string[] positionTokens = hitSliderSegmentPosition.Split(':');
                            if (positionTokens.Length == 2)
                            {
                                sliderPoints.Add(new Point((int)Convert.ToDouble(positionTokens[0], CultureInfo.InvariantCulture), (int)Convert.ToDouble(positionTokens[1], CultureInfo.InvariantCulture)));
                            }
                        }

                        int repeats = Convert.ToInt32(tokens[6]);
                        float pixelLength = ParseHelper.ToFloat(tokens[7]);

                        var timingPoint = GetTimingPointFromOffset(startTime);
                        var parentTimingPoint = timingPoint;
                        double velocity = 1;

                        if (timingPoint.BeatLength < 0)
                        {
                            velocity = Math.Abs(100 / timingPoint.BeatLength);
                            parentTimingPoint = GetParentTimingPoint(timingPoint);
                        }

                        double pixelsPerBeat = Beatmap.DifficultySection.SliderMultiplier * 100 * velocity;
                        double beats = pixelLength * repeats / pixelsPerBeat;
                        int duration = (int)Math.Ceiling(beats * parentTimingPoint.BeatLength);
                        int endTime = startTime + duration;

                        //let's just hope that the endTime algorithm is same as osu!standard
                        //TODO: test the endTime algorithm
                        hitObject = new CatchSlider(position, startTime, endTime, hitSound, isNewCombo, curveType, sliderPoints, repeats, pixelLength);
                    }
                    else
                    {
                        int endTime = Convert.ToInt32(tokens[5].Trim());
                        hitObject = new CatchSpinner(position, startTime, endTime, hitSound);
                    }
                    break;
                case Ruleset.Mania:
                    int collumn = MathHelper.CalculateCollumn(position.X, (int)Beatmap.DifficultySection.CircleSize);
                    if (type.HasFlag(HitObjectType.Circle))
                        hitObject = new ManiaSingle(position, startTime, startTime, hitSound, collumn);
                    else
                    {
                        string[] additions = tokens[5].Split(':');
                        int endTime = Convert.ToInt32(additions[0].Trim());
                        hitObject = new ManiaHold(position, startTime, endTime, hitSound, collumn);
                    }
                    break;
            }

            Beatmap.HitObjects.Add(hitObject);
        }

        private TimingPoint GetTimingPointFromOffset(int offset)
        {
            if (Beatmap.TimingPoints.Count == 0)
                return null;

            if (offset < Beatmap.TimingPoints.First().Offset)
                return Beatmap.TimingPoints.First();

            for (int i = Beatmap.TimingPoints.Count - 1; i >= 0; i--)
            {
                if (Beatmap.TimingPoints[i].Offset <= offset)
                    return Beatmap.TimingPoints[i];
            }

            return null;
        }

        private TimingPoint GetParentTimingPoint(TimingPoint child)
        {
            if (Beatmap.TimingPoints.Count == 0)
                return null;

            for (int i = Beatmap.TimingPoints.IndexOf(child) - 1; i >= 0; i--)
            {
                if (Beatmap.TimingPoints[i].BeatLength > 0)
                    return Beatmap.TimingPoints[i];
            }

            return null;
        }
    }
}
