using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestReplay : BaseTest
    {
        public override string RootPath => base.RootPath + "Replays/";

        [TestMethod]
        public void TestImportAndExportReplay()
        {
            var dic = RootPath + "andy840119 - Suzuki Konomi - DAYS of DASH (TV Size) [Hard] (2013-02-02) Osu.osr";

            //test replay
            TestReplay(dic);

            void TestReplay(string path)
            {
                //parse replay
                var replay = Parser.ParseReplay(path);

                //Export replay
                var exportPath = path + "_export";
                replay.Write(exportPath);

                //reload replay again
                var reloadReplay = Parser.ParseReplay(exportPath);

                //compare two replay
                //Note : Skip compare ReplayLength
                reloadReplay.ReplayLength = replay.ReplayLength;
                Assert.IsTrue(CompareTwoObjects(replay, reloadReplay));
            }
        }
    }
}
