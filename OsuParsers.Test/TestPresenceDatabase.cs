using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestPresenceDatabase : BaseTest
    {
        protected override string RootPath => base.RootPath + "Databases/";

        [TestMethod]
        public void TestImportAndExportPresenceDatabase()
        {
            var path = RootPath + "presence.db";

            //parse database
            var presenceDatabase = Parser.ParsePresenceDatabase(path);

            //Export database
            var exportPath = path + "_export";
            presenceDatabase.Write(exportPath);

            //reload database again
            var reloadPresenceDatabase = Parser.ParsePresenceDatabase(exportPath);

            //compare two database
            Assert.IsTrue(CompareTwoObjects(presenceDatabase, reloadPresenceDatabase));
        }
    }
}
