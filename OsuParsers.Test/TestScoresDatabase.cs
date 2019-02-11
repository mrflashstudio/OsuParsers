using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestScoresDatabase : BaseTest
    {
        public override string RootPath => base.RootPath + "Databases/";

        [TestMethod]
        public void TestImportAndExportScoreDatabase()
        {
            var path = RootPath + "scores.db";

            //parse database
            var scoresDatabase = Parser.ParseScoresDatabase(path);

            //Export database
            var exportPath = path + "_export";
            scoresDatabase.Write(exportPath);

            //reload database again
            var reloadScoresDatabase = Parser.ParseScoresDatabase(exportPath);

            //compare two database
            Assert.IsTrue(CompareTwoObjects(scoresDatabase, reloadScoresDatabase));
        }
    }
}
