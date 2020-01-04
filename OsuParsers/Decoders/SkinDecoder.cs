using OsuParsers.Enums;
using OsuParsers.Helpers;
using OsuParsers.Skins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OsuParsers.Decoders
{
    public class SkinDecoder
    {
        private static Skin skin;
        private static FileSections currentSection;

        /// <summary>
        /// Parses skin.ini file.
        /// </summary>
        /// <param name="path">Path to the skin.ini file.</param>
        /// <returns>A usable skin.</returns>
        public static Skin Decode(string path)
        {
            if (File.Exists(path))
                return Decode(File.ReadAllLines(path));
            else
                throw new FileNotFoundException();
        }

        /// <summary>
        /// Parses skin.ini file.
        /// </summary>
        /// <param name="lines">Array of text lines containing skin.ini data.</param>
        /// <returns>A usable skin.</returns>
        public static Skin Decode(IEnumerable<string> lines)
        {
            skin = new Skin();
            currentSection = FileSections.General;

            foreach (var line in lines)
            {
                string currentLine = line;

                if (currentLine.Contains("//"))
                    currentLine = currentLine.Remove(currentLine.IndexOf("//"), currentLine.Length - currentLine.IndexOf("//"));

                if (!string.IsNullOrWhiteSpace(currentLine))
                {
                    if (ParseHelper.GetCurrentSection(currentLine) != FileSections.None)
                        currentSection = ParseHelper.GetCurrentSection(currentLine);
                    else if (ParseHelper.IsLineValid(currentLine, currentSection))
                        ParseLine(currentLine);
                }
            }

            return skin;
        }

        /// <summary>
        /// Parses skin.ini file.
        /// </summary>
        /// <param name="stream">Stream containing skin.ini data.</param>
        /// <returns>A usable skin.</returns>
        public static Skin Decode(Stream stream) => Decode(stream.ReadAllLines());

        private static void ParseLine(string line)
        {
            switch (currentSection)
            {
                case FileSections.General:
                    ParseGeneral(line);
                    break;
                case FileSections.Colours:
                    ParseColours(line);
                    break;
                case FileSections.Fonts:
                    ParseFonts(line);
                    break;
                case FileSections.CatchTheBeat:
                    ParseCatchTheBeat(line);
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
                case "Name":
                    skin.GeneralSection.Name = value;
                    break;
                case "Author":
                    skin.GeneralSection.Author = value;
                    break;
                case "Version":
                    skin.GeneralSection.IsLatestVersion = value.ToLower() == "latest";
                    skin.GeneralSection.Version = skin.GeneralSection.IsLatestVersion ? Skin.LATEST_VERSION : ParseHelper.ToDouble(value);
                    break;
                case "AnimationFramerate":
                    skin.GeneralSection.AnimationFramerate = Convert.ToInt32(value);
                    break;
                case "AllowSliderBallTint":
                    skin.GeneralSection.AllowSliderBallTint = ParseHelper.ToBool(value);
                    break;
                case "ComboBurstRandom":
                    skin.GeneralSection.ComboBurstRandom = ParseHelper.ToBool(value);
                    break;
                case "CursorCentre":
                    skin.GeneralSection.CursorCentre = ParseHelper.ToBool(value);
                    break;
                case "CursorExpand":
                    skin.GeneralSection.CursorExpand = ParseHelper.ToBool(value);
                    break;
                case "CursorRotate":
                    skin.GeneralSection.CursorRotate = ParseHelper.ToBool(value);
                    break;
                case "CursorTrailRotate":
                    skin.GeneralSection.CursorTrailRotate = ParseHelper.ToBool(value);
                    break;
                case "CustomComboBurstSounds":
                    skin.GeneralSection.CustomComboBurstSounds = value.Split(',').Select(b => Convert.ToInt32(b)).ToList();
                    break;
                case "HitCircleOverlayAboveNumber":
                case "HitCircleOverlayAboveNumer":
                    skin.GeneralSection.HitCircleOverlayAboveNumber = ParseHelper.ToBool(value);
                    break;
                case "LayeredHitSounds":
                    skin.GeneralSection.LayeredHitSounds = ParseHelper.ToBool(value);
                    break;
                case "SliderBallFlip":
                    skin.GeneralSection.SliderBallFlip = ParseHelper.ToBool(value);
                    break;
                case "SliderBallFrames":
                    skin.GeneralSection.SliderBallFrames = Convert.ToInt32(value);
                    break;
                case "SliderStyle":
                    skin.GeneralSection.SliderStyle = Convert.ToInt32(value);
                    break;
                case "SpinnerFadePlayfield":
                    skin.GeneralSection.SpinnerFadePlayfield = ParseHelper.ToBool(value);
                    break;
                case "SpinnerFrequencyModulate":
                    skin.GeneralSection.SpinnerFrequencyModulate = ParseHelper.ToBool(value);
                    break;
                case "SpinnerNoBlink":
                    skin.GeneralSection.SpinnerNoBlink = ParseHelper.ToBool(value);
                    break;
            }
        }

        private static void ParseColours(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();

            switch (variable)
            {
                case "InputOverlayText":
                    skin.ColoursSection.InputOverlayText = ParseHelper.ParseColour(value);
                    break;
                case "MenuGlow":
                    skin.ColoursSection.MenuGlow = ParseHelper.ParseColour(value);
                    break;
                case "SliderBall":
                    skin.ColoursSection.SliderBall = ParseHelper.ParseColour(value);
                    break;
                case "SliderBorder":
                    skin.ColoursSection.SliderBorder = ParseHelper.ParseColour(value);
                    break;
                case "SliderTrackOverride":
                    skin.ColoursSection.SliderTrackOverride = ParseHelper.ParseColour(value);
                    break;
                case "SongSelectActiveText":
                    skin.ColoursSection.SongSelectActiveText = ParseHelper.ParseColour(value);
                    break;
                case "SongSelectInactiveText":
                    skin.ColoursSection.SongSelectInactiveText = ParseHelper.ParseColour(value);
                    break;
                case "SpinnerBackground":
                    skin.ColoursSection.SpinnerBackground = ParseHelper.ParseColour(value);
                    break;
                case "StarBreakAdditive":
                    skin.ColoursSection.StarBreakAdditive = ParseHelper.ParseColour(value);
                    break;
                default:
                    skin.ColoursSection.ComboColours.Add(ParseHelper.ParseColour(value));
                    break;
            }
        }

        private static void ParseFonts(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();

            switch (variable)
            {
                case "HitCirclePrefix":
                    skin.FontsSection.HitCirclePrefix = value;
                    break;
                case "HitCircleOverlap":
                    skin.FontsSection.HitCircleOverlap = Convert.ToInt32(value);
                    break;
                case "ScorePrefix":
                    skin.FontsSection.ScorePrefix = value;
                    break;
                case "ScoreOverlap":
                    skin.FontsSection.ScoreOverlap = Convert.ToInt32(value);
                    break;
                case "ComboPrefix":
                    skin.FontsSection.ComboPrefix = value;
                    break;
                case "ComboOverlap":
                    skin.FontsSection.ComboOverlap = Convert.ToInt32(value);
                    break;
            }
        }

        private static void ParseCatchTheBeat(string line)
        {
            int index = line.IndexOf(':');
            string variable = line.Remove(index).Trim();
            string value = line.Remove(0, index + 1).Trim();

            switch (variable)
            {
                case "HyperDash":
                    skin.CatchTheBeatSection.HyperDash = ParseHelper.ParseColour(value);
                    break;
                case "HyperDashFruit":
                    skin.CatchTheBeatSection.HyperDashFruit = ParseHelper.ParseColour(value);
                    break;
                case "HyperDashAfterImage":
                    skin.CatchTheBeatSection.HyperDashAfterImage = ParseHelper.ParseColour(value);
                    break;
            }
        }
    }
}
