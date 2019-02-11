using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Catch;
using OsuParsers.Enums;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestCatchHitObject : BaseHitObjectTest
    {
        [TestMethod]
        public void TestCatchHitobjects()
        {
            var beatmap = GenerateBeatmap(Ruleset.Fruits);

            //Create Droplets
            beatmap.HitObjects.Add(new CatchDroplets(new Point(100, 100), 1000, -2147482648, HitSoundType.Clap
                , CurveType.Bezier, new List<Point>(), 1, 0, new List<HitSoundType>()
                , new List<Tuple<SampleSet, SampleSet>>(), new Extras(), false, 0));

            //Create Fruit
            beatmap.HitObjects.Add(new CatchFruit(new Point(200,200), 3000, 3000, HitSoundType.Clap, new Extras(),true, 0));

            //Create Spinner
            beatmap.HitObjects.Add(new CatchSpinner(new Point(300,300),5000,6000, HitSoundType.Finish, new Extras(), false, 0));

            //compare with exported beatmap
            Assert.IsTrue(CompareOriginAndReloadBeatmap(beatmap));
        }
    }
}
