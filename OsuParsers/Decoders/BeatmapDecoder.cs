using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Catch;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Beatmaps.Sections.Events;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace OsuParsers.Decoders
{
    public static class BeatmapDecoder
    {
        private static Beatmap Beatmap;
        private static Sections currentSection = Sections.None;
        private static List<string> sbLines = new List<string>();

        /// <summary>
        /// Parses .osu file.
        /// </summary>
        /// <param name="path">Path to the .osu file.</param>
        /// <returns>A usable beatmap.</returns>
        public static Beatmap Decode(string path)
        {
            if (File.Exists(path))
                return Decode(File.ReadAllLines(path));
            else
                throw new FileNotFoundException();
        }

        /// <summary>
        /// Parses .osu file.
        /// </summary>
        /// <param name="lines">Array of text lines containing beatmap data.</param>
        /// <returns>A usable beatmap.</returns>
        public static Beatmap Decode(IEnumerable<string> lines)
        {
            Beatmap = new Beatmap();
            currentSection = Sections.Format;
            sbLines.Clear();

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//"))
                {
                    if (ParseHelper.GetCurrentSection(line) != Sections.None)
                        currentSection = ParseHelper.GetCurrentSection(line);
                    else if (ParseHelper.IsLineValid(line, currentSection))
                        ParseLine(line);
                }
            }

            Beatmap.EventsSection.Storyboard = StoryboardDecoder.Decode(sbLines.ToArray());

            Beatmap.GeneralSection.CirclesCount = Beatmap.HitObjects.Count(c => c is HitCircle || c is TaikoHit || c is ManiaNote || c is CatchFruit);
            Beatmap.GeneralSection.SlidersCount = Beatmap.HitObjects.Count(c => c is Slider || c is TaikoDrumroll || c is ManiaHoldNote || c is CatchJuiceStream);
            Beatmap.GeneralSection.SpinnersCount = Beatmap.HitObjects.Count(c => c is Spinner || c is TaikoSpinner || c is CatchBananaRain);

            Beatmap.GeneralSection.Length = Beatmap.HitObjects.Count > 0 ? Beatmap.HitObjects.Last().EndTime / 1000 : 0;

            return Beatmap;
        }

        /// <summary>
        /// Parses .osu file.
        /// </summary>
        /// <param name="stream">Stream containing beatmap data.</param>
        /// <returns>A usable beatmap.</returns>
        public static Beatmap Decode(Stream stream) => Decode(stream.ReadAllLines());

        private static void ParseLine(string line)
        {
            switch (currentSection)
            {
                case Sections.Format:
                    Beatmap.Version = Convert.ToInt32(line.Split(new string[] { "osu file format v" }, StringSplitOptions.None)[1]);
                    break;
                case Sections.General:
                    ParseGeneral(line);
                    break;
                case Sections.Editor:
                    ParseEditor(line);
                    break;
                case Sections.Metadata:
                    ParseMetadata(line);
                    break;
                case Sections.Difficulty:
                    ParseDifficulty(line);
                    break;
                case Sections.Events:
                    ParseEvents(line);
                    break;
                case Sections.TimingPoints:
                    ParseTimingPoints(line);
                    break;
                case Sections.Colours:
                    ParseColours(line);
                    break;
                case Sections.HitObjects:
                    ParseHitObjects(line);
                    break;
            }
        }

        private static void ParseGeneral(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();
            switch (variable)
            {
                case "AudioFilename":
                    Beatmap.GeneralSection.AudioFilename = value.Trim();
                    break;
                case "AudioLeadIn":
                    Beatmap.GeneralSection.AudioLeadIn = Convert.ToInt32(value.Trim());
                    break;
                case "PreviewTime":
                    Beatmap.GeneralSection.PreviewTime = Convert.ToInt32(value.Trim());
                    break;
                case "Countdown":
                    Beatmap.GeneralSection.Countdown = ParseHelper.ToBool(value.Trim());
                    break;
                case "SampleSet":
                    Beatmap.GeneralSection.SampleSet = (SampleSet)Enum.Parse(typeof(SampleSet), value.Trim());
                    break;
                case "StackLeniency":
                    Beatmap.GeneralSection.StackLeniency = ParseHelper.ToDouble(value.Trim());
                    break;
                case "Mode":
                    Beatmap.GeneralSection.Mode = (Ruleset)Enum.Parse(typeof(Ruleset), value.Trim());
                    Beatmap.GeneralSection.ModeId = Convert.ToInt32(value.Trim());
                    break;
                case "LetterboxInBreaks":
                    Beatmap.GeneralSection.LetterboxInBreaks = ParseHelper.ToBool(value.Trim());
                    break;
                case "WidescreenStoryboard":
                    Beatmap.GeneralSection.WidescreenStoryboard = ParseHelper.ToBool(value.Trim());
                    break;
                case "StoryFireInFront":
                    Beatmap.GeneralSection.StoryFireInFront = ParseHelper.ToBool(value.Trim());
                    break;
                case "SpecialStyle":
                    Beatmap.GeneralSection.SpecialStyle = ParseHelper.ToBool(value.Trim());
                    break;
                case "EpilepsyWarning":
                    Beatmap.GeneralSection.EpilepsyWarning = ParseHelper.ToBool(value.Trim());
                    break;
                case "UseSkinSprites":
                    Beatmap.GeneralSection.UseSkinSprites = ParseHelper.ToBool(value.Trim());
                    break;
            }
        }

        private static void ParseEditor(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();
            switch (variable)
            {
                case "Bookmarks":
                    Beatmap.EditorSection.Bookmarks = value.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(b => Convert.ToInt32(b)).ToArray();
                    break;
                case "DistanceSpacing":
                    Beatmap.EditorSection.DistanceSpacing = ParseHelper.ToDouble(value.Trim());
                    break;
                case "BeatDivisor":
                    Beatmap.EditorSection.BeatDivisor = Convert.ToInt32(value.Trim());
                    break;
                case "GridSize":
                    Beatmap.EditorSection.GridSize = Convert.ToInt32(value.Trim());
                    break;
                case "TimelineZoom":
                    Beatmap.EditorSection.TimelineZoom = ParseHelper.ToFloat(value.Trim());
                    break;
            }
        }

        private static void ParseMetadata(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();
            switch (variable)
            {
                case "Title":
                    Beatmap.MetadataSection.Title = value.Trim();
                    break;
                case "TitleUnicode":
                    Beatmap.MetadataSection.TitleUnicode = value.Trim();
                    break;
                case "Artist":
                    Beatmap.MetadataSection.Artist = value.Trim();
                    break;
                case "ArtistUnicode":
                    Beatmap.MetadataSection.ArtistUnicode = value.Trim();
                    break;
                case "Creator":
                    Beatmap.MetadataSection.Creator = value.Trim();
                    break;
                case "Version":
                    Beatmap.MetadataSection.Version = value.Trim();
                    break;
                case "Source":
                    Beatmap.MetadataSection.Source = value.Trim();
                    break;
                case "Tags":
                    Beatmap.MetadataSection.Tags = value.Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "BeatmapID":
                    Beatmap.MetadataSection.BeatmapID = Convert.ToInt32(value.Trim());
                    break;
                case "BeatmapSetID":
                    Beatmap.MetadataSection.BeatmapSetID = Convert.ToInt32(value.Trim());
                    break;
            }
        }

        private static void ParseDifficulty(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();
            switch (variable)
            {
                case "HPDrainRate":
                    Beatmap.DifficultySection.HPDrainRate = ParseHelper.ToFloat(value.Trim());
                    break;
                case "CircleSize":
                    Beatmap.DifficultySection.CircleSize = ParseHelper.ToFloat(value.Trim());
                    break;
                case "OverallDifficulty":
                    Beatmap.DifficultySection.OverallDifficulty = ParseHelper.ToFloat(value.Trim());
                    break;
                case "ApproachRate":
                    Beatmap.DifficultySection.ApproachRate = ParseHelper.ToFloat(value.Trim());
                    break;
                case "SliderMultiplier":
                    Beatmap.DifficultySection.SliderMultiplier = ParseHelper.ToDouble(value.Trim());
                    break;
                case "SliderTickRate":
                    Beatmap.DifficultySection.SliderTickRate = ParseHelper.ToDouble(value.Trim());
                    break;
            }
        }

        private static void ParseEvents(string line)
        {
            string[] tokens = line.Split(',');

            EventType eventType = default(EventType);

            if (Enum.TryParse(tokens[0], out EventType e))
                eventType = (EventType)Enum.Parse(typeof(EventType), tokens[0]);
            else if (line.StartsWith(" ") || line.StartsWith("_"))
                eventType = EventType.StoryboardCommand;
            else
                return;

            switch (eventType)
            {
                case EventType.Background:
                    Beatmap.EventsSection.BackgroundImage = tokens[2].Trim('"');
                    break;
                case EventType.Video:
                    Beatmap.EventsSection.Video = tokens[2].Trim('"');
                    Beatmap.EventsSection.VideoOffset = Convert.ToInt32(tokens[1]);
                    break;
                case EventType.Break:
                    Beatmap.EventsSection.Breaks.Add(new BreakEvent(Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2])));
                    break;
                case EventType.Sprite:
                case EventType.Animation:
                case EventType.Sample:
                case EventType.StoryboardCommand:
                    sbLines.Add(line);
                    break;
            }
        }

        private static void ParseTimingPoints(string line)
        {
            string[] tokens = line.Split(',');

            int offset = (int)ParseHelper.ToFloat(tokens[0]);
            double beatLength = ParseHelper.ToDouble(tokens[1]);
            TimeSignature timeSignature = TimeSignature.SimpleQuadruple;
            SampleSet sampleSet = SampleSet.None;
            int customSampleSet = 0;
            int volume = 100;
            bool inherited = true;
            Effects effects = Effects.None;

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
                effects = (Effects)Convert.ToInt32(tokens[7]);

            Beatmap.TimingPoints.Add(new TimingPoint
            {
                Offset = offset,
                BeatLength = beatLength,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = inherited,
                Effects = effects
            });
        }

        private static void ParseColours(string line)
        {
            string variable = line.Split(':')[0].Trim();

            switch (variable)
            {
                case "SliderTrackOverride":
                    Beatmap.ColoursSection.SliderTrackOverride = ParseHelper.ParseColour(line);
                    break;
                case "SliderBorder":
                    Beatmap.ColoursSection.SliderBorder = ParseHelper.ParseColour(line);
                    break;
                default:
                    Beatmap.ColoursSection.ComboColours.Add(ParseHelper.ParseColour(line));
                    break;
            }
        }

        private static void ParseHitObjects(string line)
        {
            string[] tokens = line.Split(',');

            Vector2 position = new Vector2(ParseHelper.ToFloat(tokens[0]), ParseHelper.ToFloat(tokens[1]));

            int startTime = Convert.ToInt32(tokens[2]);

            HitObjectType type = (HitObjectType)int.Parse(tokens[3]);

            int comboOffset = (int)(type & HitObjectType.ComboOffset) >> 4;
            type &= ~HitObjectType.ComboOffset;

            bool isNewCombo = type.HasFlag(HitObjectType.NewCombo);
            type &= ~HitObjectType.NewCombo;

            HitSoundType hitSound = (HitSoundType)Convert.ToInt32(tokens[4]);

            HitObject hitObject = null;

            string[] extrasSplit = tokens.Last().Split(':');
            int extrasOffset = type.HasFlag(HitObjectType.Hold) ? 1 : 0;
            Extras extras = tokens.Last().Contains(":") ? new Extras
            {
                SampleSet = (SampleSet)Convert.ToInt32(extrasSplit[0 + extrasOffset]),
                AdditionSet = (SampleSet)Convert.ToInt32(extrasSplit[1 + extrasOffset]),
                CustomIndex = extrasSplit.Length > 2 + extrasOffset ? Convert.ToInt32(extrasSplit[2 + extrasOffset]) : 0,
                Volume = extrasSplit.Length > 3 + extrasOffset ? Convert.ToInt32(extrasSplit[3 + extrasOffset]) : 0,
                SampleFileName = extrasSplit.Length > 4 + extrasOffset ? extrasSplit[4 + extrasOffset] : string.Empty
            } : new Extras();

            switch (type)
            {
                case HitObjectType.Circle:
                {
                    if (Beatmap.GeneralSection.Mode == Ruleset.Standard)
                        hitObject = new HitCircle(position, startTime, startTime, hitSound, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Taiko)
                        hitObject = new TaikoHit(position, startTime, startTime, hitSound, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Fruits)
                        hitObject = new CatchFruit(position, startTime, startTime, hitSound, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Mania)
                        hitObject = new ManiaNote(position, startTime, startTime, hitSound, extras, isNewCombo, comboOffset);
                }
                    break;
                case HitObjectType.Slider:
                {
                    CurveType curveType = ParseHelper.GetCurveType(tokens[5].Split('|')[0][0]);
                    List<Vector2> sliderPoints = ParseHelper.GetSliderPoints(tokens[5].Split('|'));

                    int repeats = Convert.ToInt32(tokens[6]);
                    double pixelLength = ParseHelper.ToDouble(tokens[7]);

                    int endTime = MathHelper.CalculateEndTime(Beatmap, startTime, repeats, pixelLength);

                    List<HitSoundType> edgeHitSounds = null;
                    if (tokens.Length > 8 && tokens[8].Length > 0)
                    {
                        edgeHitSounds = new List<HitSoundType>();
                        edgeHitSounds = Array.ConvertAll(tokens[8].Split('|'), s => (HitSoundType)Convert.ToInt32(s)).ToList();
                    }

                    List<Tuple<SampleSet, SampleSet>> edgeAdditions = null;
                    if (tokens.Length > 9 && tokens[9].Length > 0)
                    {
                        edgeAdditions = new List<Tuple<SampleSet, SampleSet>>();
                        foreach (var s in tokens[9].Split('|'))
                        {
                            edgeAdditions.Add(new Tuple<SampleSet, SampleSet>((SampleSet)Convert.ToInt32(s.Split(':').First()), (SampleSet)Convert.ToInt32(s.Split(':').Last())));
                        }
                    }

                    if (Beatmap.GeneralSection.Mode == Ruleset.Standard)
                        hitObject = new Slider(position, startTime, endTime, hitSound, curveType, sliderPoints, repeats,
                            pixelLength, edgeHitSounds, edgeAdditions, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Taiko)
                        hitObject = new TaikoDrumroll(position, startTime, endTime, hitSound, curveType, sliderPoints,
                            repeats, pixelLength, edgeHitSounds, edgeAdditions, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Fruits)
                        hitObject = new CatchJuiceStream(position, startTime, endTime, hitSound, curveType, sliderPoints,
                            repeats, pixelLength, edgeHitSounds, edgeAdditions, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Mania)
                        hitObject = new ManiaHoldNote(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset);
                }
                    break;
                case HitObjectType.Spinner:
                {
                    int endTime = Convert.ToInt32(tokens[5].Trim());

                    if (Beatmap.GeneralSection.Mode == Ruleset.Standard)
                        hitObject = new Spinner(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Taiko)
                        hitObject = new TaikoSpinner(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset);
                    else if (Beatmap.GeneralSection.Mode == Ruleset.Fruits)
                        hitObject = new CatchBananaRain(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset);
                }
                    break;
                case HitObjectType.Hold:
                {
                    string[] additions = tokens[5].Split(':');
                    int endTime = Convert.ToInt32(additions[0].Trim());
                    hitObject = new ManiaHoldNote(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset);
                }
                    break;
            }

            Beatmap.HitObjects.Add(hitObject);
        }
    }
}