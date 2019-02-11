using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Enums;

namespace OsuParsers.Test
{
    public class BaseHitObjectTest : BaseTest
    {
        private Random readom = new Random();

        protected Beatmap GenerateBeatmap(Ruleset ruleset)
        {
            return new Beatmap
            {
                Version = 1,
                GeneralSection = new GeneralSection
                {
                    AudioFilename = "AudioFilename",//Must have value to pass the test
                    Countdown = true,
                    Mode = ruleset,//Must have value to pass the test
                    ModeId = (int)ruleset,//Must have value to pass the test
                },
                EditorSection = new EditorSection
                {

                },
                MetadataSection = new MetadataSection
                {
                    Title = "Title",//Must have value to pass the test
                    TitleUnicode = "TitleUnicode",//Must have value to pass the test
                    Artist = "Artist",//Must have value to pass the test
                    ArtistUnicode = "ArtistUnicode",//Must have value to pass the test
                    Creator = "Creator",//Must have value to pass the test
                    Version = "Version",//Must have value to pass the test
                    Source = "Source",//Must have value to pass the test
                    Tags = new []{ "Tag001" ,"Tag002","Tag003" }//Must have value to pass the test
                },
                EventsSection = new EventsSection
                {

                    BackgroundImage = "BackgroundImage.png"//Must have value to pass the test
                }
            };
        }

        protected bool CompareOriginAndReloadBeatmap(Beatmap beatmap)
        {
            //Export beatmap
            var exportPath = $"test_beatmap{readom.Next(10000)}_export";
            beatmap.Write(exportPath);

            //reload beatmap again
            var reloadBeatmap = Parser.ParseBeatmap(exportPath);

            //apply value
            beatmap.GeneralSection.CirclesCount = reloadBeatmap.GeneralSection.CirclesCount;
            beatmap.GeneralSection.SlidersCount = reloadBeatmap.GeneralSection.SlidersCount;
            beatmap.GeneralSection.SpinnersCount = reloadBeatmap.GeneralSection.SpinnersCount;
            beatmap.GeneralSection.Length = reloadBeatmap.GeneralSection.Length;

            //compare beatmap1 and beatmap2
            if (!CompareTwoObjects(beatmap, reloadBeatmap))
                return false;

            //reload beatmap again
            var exportPathAgain = exportPath + "2";
            reloadBeatmap.Write(exportPathAgain);
            var reloadBeatmapAgain = Parser.ParseBeatmap(exportPathAgain);

            //compare beatmap2 and beatmap3
            return CompareTwoObjects(reloadBeatmap, reloadBeatmapAgain);
        }
    }
}
