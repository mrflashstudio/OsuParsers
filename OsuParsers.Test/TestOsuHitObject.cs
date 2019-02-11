using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Enums;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestOsuHitObject : BaseHitObjectTest
    {
        [TestMethod]
        public void TestOsuHitobjects()
        {
            var beatmap = GenerateBeatmap(Ruleset.Standard);

            //Create Slider
            beatmap.HitObjects.Add(new Slider(new Point(100, 100), 1000, -2147482648, HitSoundType.Clap
                , CurveType.Bezier, new List<Point>(), 1, 0, new List<HitSoundType>()
                , new List<Tuple<SampleSet, SampleSet>>(), new Extras(), false, 0));

            //Create HitObject
            beatmap.HitObjects.Add(new Circle(new Point(200, 200), 3000, 3000, HitSoundType.Clap, new Extras(), true, 0));

            //Create Spinner
            beatmap.HitObjects.Add(new Spinner(new Point(300, 300), 5000, 6000, HitSoundType.Finish, new Extras(), false, 0));

            //compare with exported beatmap
            Assert.IsTrue(CompareOriginAndReloadBeatmap(beatmap));
        }
    }
}
