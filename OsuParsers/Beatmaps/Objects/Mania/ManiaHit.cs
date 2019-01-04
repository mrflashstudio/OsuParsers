using System;
using System.Drawing;
using OsuParsers.Enums;

namespace OsuParsers.Beatmaps.Objects.Mania
{
    public class ManiaHit : Circle
    {
        public ManiaHit(Point position, int startTime, int endTime, HitSoundType hitSound, Extras extras, bool isNewCombo, int comboOffset) 
            : base(position, startTime, endTime, hitSound, extras, isNewCombo, comboOffset)
        {
        }

        public void SetColumn(int count, int column)
        {
            double width = 512.0 / count;
            int x = Convert.ToInt32(Math.Floor(column * width));
            Position = new Point(x, 0);
        }

        public int GetColumn(int count)
        {
            double width = 512.0 / count;
            return Convert.ToInt32(Position.X / width);
        }

        public new Point Position
        {
            set => base.Position = value;
            get => new Point(base.Position.X, 0);
        }
    }
}
