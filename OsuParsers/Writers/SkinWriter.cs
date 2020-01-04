using OsuParsers.Helpers;
using OsuParsers.Skins;
using OsuParsers.Skins.Sections;
using System.Collections.Generic;
using System.Linq;

namespace OsuParsers.Writers
{
    internal class SkinWriter
    {
        public static List<string> Write(Skin skin)
        {
            var Sections = new List<List<string>>
            {
                GeneralSection(skin.GeneralSection),
                ColoursSection(skin.ColoursSection),
                FontsSection(skin.FontsSection),
                CatchTheBeatSection(skin.CatchTheBeatSection)
            };

            List<string> contents = new List<string>();
            Sections.ForEach(stringList => stringList.ForEach(item => contents.Add(item)));
            return contents;
        }

        private static List<string> GeneralSection(SkinGeneralSection section)
        {
            var list = new List<string>(new string[]
            {
                "[General]",
                $"Author: {section.Author}",
                $"Name: {section.Name}",
                $"Version: {(section.IsLatestVersion ? "latest" : section.Version.Format())}",
                $"AnimationFramerate: {section.AnimationFramerate.Format()}",
                $"AllowSliderBallTint: {section.AllowSliderBallTint.ToInt32()}",
                $"ComboBurstRandom: {section.ComboBurstRandom.ToInt32()}",
                $"CursorCentre: {section.CursorCentre.ToInt32()}",
                $"CursorExpand: {section.CursorExpand.ToInt32()}",
                $"CursorRotate: {section.CursorRotate.ToInt32()}",
                $"CursorTrailRotate: {section.CursorTrailRotate.ToInt32()}"
            });

            if (section.CustomComboBurstSounds.Any())
                list.Add($"CustomComboBurstSounds: {section.CustomComboBurstSounds.Join(',')}");

            list.AddRange(new string[]
            {
                $"HitCircleOverlayAboveNumber: {section.HitCircleOverlayAboveNumber.ToInt32()}",
                $"LayeredHitSounds: {section.LayeredHitSounds.ToInt32()}",
                $"SliderBallFlip: {section.SliderBallFlip.ToInt32()}",
                $"SliderBallFrames: {section.SliderBallFrames.Format()}",
                $"SliderStyle: {section.SliderStyle.Format()}",
                $"SpinnerFadePlayfield: {section.SpinnerFadePlayfield.ToInt32()}",
                $"SpinnerFrequencyModulate: {section.SpinnerFrequencyModulate.ToInt32()}",
                $"SpinnerNoBlink: {section.SpinnerNoBlink.ToInt32()}",
            });

            return list;
        }

        private static List<string> ColoursSection(SkinColoursSection section)
        {
            var list = WriteHelper.BaseListFormat("Colours");

            for (int i = 0; i < section.ComboColours.Count; i++)
                list.Add($"Combo{i + 1} : {WriteHelper.Colour(section.ComboColours[i])}");

            list.AddRange(new string[]
            {
                $"InputOverlayText: {WriteHelper.Colour(section.InputOverlayText)}",
                $"MenuGlow: {WriteHelper.Colour(section.MenuGlow)}",
                $"SliderBall: {WriteHelper.Colour(section.SliderBall)}",
                $"SliderBorder: {WriteHelper.Colour(section.SliderBorder)}"
            });

            if (section.SliderTrackOverride != default)
                list.Add($"SliderTrackOverride: {WriteHelper.Colour(section.SliderTrackOverride)}");

            list.AddRange(new string[]
            {
                $"SongSelectActiveText: {WriteHelper.Colour(section.SongSelectActiveText)}",
                $"SongSelectInactiveText: {WriteHelper.Colour(section.SongSelectInactiveText)}",
                $"SpinnerBackground: {WriteHelper.Colour(section.SpinnerBackground)}",
                $"StarBreakAdditive: {WriteHelper.Colour(section.StarBreakAdditive)}"
            });

            return list;
        }

        private static List<string> FontsSection(SkinFontsSection section)
        {
            var list = WriteHelper.BaseListFormat("Fonts");

            list.AddRange(new string[]
            {
                $"HitCirclePrefix: {section.HitCirclePrefix}",
                $"HitCircleOverlap: {section.HitCircleOverlap.Format()}",
                $"ScorePrefix: {section.ScorePrefix}",
                $"ScoreOverlap: {section.ScoreOverlap.Format()}",
                $"ComboPrefix: {section.ComboPrefix}",
                $"ComboOverlap: {section.ComboOverlap.Format()}",
            });

            return list;
        }

        private static List<string> CatchTheBeatSection(SkinCatchTheBeatSection section)
        {
            var list = WriteHelper.BaseListFormat("CatchTheBeat");

            list.Add($"HyperDash: {WriteHelper.Colour(section.HyperDash)}");

            if (section.HyperDashFruit != section.HyperDash)
                list.Add($"HyperDashFruit: {WriteHelper.Colour(section.HyperDashFruit)}");

            if (section.HyperDashAfterImage != section.HyperDash)
                list.Add($"HyperDashAfterImage: {WriteHelper.Colour(section.HyperDashAfterImage)}");

            return list;
        }
    }
}
