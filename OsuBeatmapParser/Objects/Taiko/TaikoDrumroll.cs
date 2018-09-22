using OsuBeatmapParser.Enums;
using System;
using System.Drawing;

namespace OsuBeatmapParser.Objects.Taiko
{
    public class TaikoDrumroll : TaikoHitObject
    {
        public int PixelLength { get; }
        public bool IsBig { get; }
        public HitSoundType[] EdgeHitSounds { get; }
        public Tuple<SampleSet, SampleSet>[] EdgeAdditions { get; }

        public TaikoDrumroll(Point position, int startTime, int endTime, HitSoundType hitSound, int pixelLength, 
            bool isBig, HitSoundType[] edgeHitSounds, Tuple<SampleSet, SampleSet>[] edgeAdditions, HitObjectExtras extras)
            : base(position, startTime, endTime, hitSound, extras)
        {
            PixelLength = pixelLength;
            IsBig = isBig;
            EdgeHitSounds = edgeHitSounds;
            EdgeAdditions = edgeAdditions;
        }
    }
}
