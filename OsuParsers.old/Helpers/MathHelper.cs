using OsuParsers.Beatmaps.Objects;
using System;

namespace OsuParsers.Helpers
{
    internal class MathHelper
    {
        public static double Clamp(double value, double min, double max)
        {
            if (value > max)
            {
                return max;
            }

            if (value < min)
            {
                return min;
            }

            return value;
        }

        public static double CalculateBpmMultiplier(TimingPoint timingPoint)
        {
            if (timingPoint.BeatLength >= 0) return 1;

            return Clamp((float)-timingPoint.BeatLength, 10, 1000) / 100f;
        }
    }
}
