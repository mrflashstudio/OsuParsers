using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestBeatmap : BaseTest
    {
        public override string RootPath => base.RootPath + "Beatmaps/";

        [TestMethod]
        public void TestImportAndExportBeatmap()
        {
            //Test beatmap 002
            //TODO : fix error while hitobject's format is 88,271,350,6,0,L|84:338,2,56,2|2|2,0:0|0:0|0:00:0:0:0:
            var dic = RootPath + "538998 chano 40mP - Natsukoi Hanab/";
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [Hard].osu");
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [Insane].osu");
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [N a s y a's Insane].osu");
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [Normal].osu");
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [Smokeman's Advanced].osu");
            TestBeatmap(dic + "chano & 40mP - Natsukoi Hanabi (Riven) [Spark of Light].osu");

            //Test beatmap 001
            //Okey with hitobject's format is 448,192,160,5,4,0:0:0:80:
            dic = RootPath + "540058 Kana Nishino - Distance/";
            TestBeatmap(dic + "Kana Nishino - Distance (TANUKI's Christmas Remix) (arcwinolivirus) [Faraway].osu");

            void TestBeatmap(string path)
            {
                //parse beatmap
                var beatmap = Parser.ParseBeatmap(path);

                //Export beatmap
                var exportPath = path + "_export";
                beatmap.Write(exportPath);

                //reload beatmap again
                var reloadBeatmap = Parser.ParseBeatmap(exportPath);

                //compare two beatmaps
                Assert.IsTrue(CompareTwoObjects(beatmap, reloadBeatmap));
            }
        }
    }
}
