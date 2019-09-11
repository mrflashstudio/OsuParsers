using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;

namespace OsuParsers.Helpers
{
    internal class MathHelper
    {
        public static double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            else if (value < min)
                return min;
            else
                return value;
        }

        public static double CalculateBpmMultiplier(TimingPoint timingPoint)
        {
            if (timingPoint.BeatLength >= 0)
                return 1;
            else
                return Clamp((float)-timingPoint.BeatLength, 10, 1000) / 100f;
        }

        public static int CalculateEndTime(Beatmap beatmap, int startTime, int repeats, double pixelLength)
        {
            int duration = (int)(pixelLength / (100d * beatmap.DifficultySection.SliderMultiplier) * repeats * beatmap.BeatLengthAt(startTime));
            return startTime + duration;
        }
    }
}
