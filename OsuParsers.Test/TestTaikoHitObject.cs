using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Enums;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestTaikoHitObject : BaseHitObjectTest
    {
        [TestMethod]
        public void TestTaikoHitobjects()
        {
            var beatmap = GenerateBeatmap(Ruleset.Taiko);

            //Create TaikoDrumroll
            beatmap.HitObjects.Add(new TaikoDrumroll(new Point(100, 100), 1000, -2147482648, HitSoundType.Clap
                , CurveType.Bezier, new List<Point>(), 1, 0, new List<HitSoundType>()
                , new List<Tuple<SampleSet, SampleSet>>(), new Extras(), false, 0));

            //Create TaikoHit
            beatmap.HitObjects.Add(new TaikoHit(new Point(200, 200), 3000, 3000, HitSoundType.Clap, new Extras(), true, 0));

            //Create TaikoSpinner
            beatmap.HitObjects.Add(new TaikoSpinner(new Point(300, 300), 5000, 6000, HitSoundType.Finish, new Extras(), false, 0));

            //compare with exported beatmap
            Assert.IsTrue(CompareOriginAndReloadBeatmap(beatmap));
        }
    }
}
