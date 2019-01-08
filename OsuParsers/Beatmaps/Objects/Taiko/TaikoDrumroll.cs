using System;
using System.Collections.Generic;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Taiko
{
    public class TaikoDrumroll : Slider
    {
        public bool IsBig
        {
            get
            {
                return HitSound.HasFlag(HitSoundType.Finish);
            }
            set
            {
                if (value && !HitSound.HasFlag(HitSoundType.Finish))
                    HitSound += (int)HitSoundType.Finish;
                else
                    if (HitSound.HasFlag(HitSoundType.Finish))
                    HitSound -= (int)HitSoundType.Finish;
            }
        }

        public TaikoDrumroll(Point position, int startTime, int endTime, HitSoundType hitSound, CurveType type, 
            List<Point> points, int repeats, double pixelLength, List<HitSoundType> edgeHitSounds,
            List<Tuple<SampleSet, SampleSet>> edgeAdditions, Extras extras, bool isNewCombo, int comboOffset) 
            : base(position, startTime, endTime, hitSound, type, points, repeats, pixelLength, edgeHitSounds, edgeAdditions, extras, isNewCombo, comboOffset)
        {
        }
    }
}
