using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestCollectionDatabase : BaseTest
    {
        public override string RootPath => base.RootPath + "Databases/";

        [TestMethod]
        public void TestImportAndExportPresenceDatabase()
        {
            var path = RootPath + "collection.db";

            //parse database
            var collectionDatabase = Parser.ParseCollectionDatabase(path);

            //Export database
            var exportPath = path + "_export";
            collectionDatabase.Write(exportPath);

            //reload database again
            var reloadCollectionDatabase = Parser.ParseCollectionDatabase(exportPath);

            //compare two database
            Assert.IsTrue(CompareTwoObjects(collectionDatabase, reloadCollectionDatabase));
        }
    }
}
