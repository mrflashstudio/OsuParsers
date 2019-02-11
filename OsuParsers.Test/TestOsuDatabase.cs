using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestOsuDatabase : BaseTest
    {
        protected override string RootPath => base.RootPath + "Databases/";

        [TestMethod]
        public void TestImportAndExportPresenceDatabase()
        {
            var path = RootPath + "osu!.db";

            //parse database
            var osuDatabase = Parser.ParseOsuDatabase(path);

            //Export database
            var exportPath = path + "_export";


            osuDatabase.Beatmaps.RemoveRange(500, osuDatabase.Beatmaps.Count - 500);
            osuDatabase.BeatmapCount = 500;
            osuDatabase.FolderCount = 500;


            osuDatabase.Write(exportPath);

            //reload database again
            var reloadOsuDatabase = Parser.ParseOsuDatabase(exportPath);

            //compare two database
            Assert.IsTrue(CompareTwoObjects(osuDatabase, reloadOsuDatabase));
        }
    }
}
