using OsuParsers.Enums.Beatmaps;
using System;
using System.Numerics;

namespace OsuParsers.Beatmaps.Objects.Mania
{
    public class ManiaNote : HitCircle
    {
        public ManiaNote(Vector2 position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset)
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
        }

        /// <summary>
        /// Sets column of this object.
        /// </summary>
        /// <param name="count">Total number of columns of this beatmap. Usually it's CircleSize.</param>
        /// <param name="column">Index of the column you want to set. Should start from 0. e.g. index of first column is 0.</param>
        public void SetColumn(int count, int column)
        {
            double width = 512.0 / count;
            int x = Convert.ToInt32(Math.Floor(column * width));
            Position = new Vector2(x, 0);
        }

        /// <summary>
        /// Returns column of this object.
        /// </summary>
        /// <param name="count">Total number of columns of this beatmap. Usually it's CircleSize.</param>
        public int GetColumn(int count)
        {
            double width = 512.0 / count;
            return (int)(Position.X / width);
        }

        public new Vector2 Position
        {
            set => base.Position = value;
            get => new Vector2(base.Position.X, 0);
        }
    }
}
