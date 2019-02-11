using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums;

namespace OsuParsers.Test
{
    [TestClass]
    public class TestManiaHitObject : BaseHitObjectTest
    {
        [TestMethod]
        public void TestManiaHitobjects()
        {
            var beatmap = GenerateBeatmap(Ruleset.Mania);

            //Create ManiaHit
            beatmap.HitObjects.Add(new ManiaHit(new Point(100, 100), 1000, 1000, HitSoundType.Clap, new Extras(), false, 0));

            //Create ManiaHold
            beatmap.HitObjects.Add(new ManiaHold(new Point(200, 200), 3000, 4000, HitSoundType.Clap, new Extras(), true, 0));

            //compare with exported beatmap
            Assert.IsTrue(CompareOriginAndReloadBeatmap(beatmap));
        }
    }
}
