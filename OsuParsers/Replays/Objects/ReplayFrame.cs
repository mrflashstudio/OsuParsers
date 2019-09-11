using OsuParsers.Enums.Replays;

namespace OsuParsers.Replays.Objects
{
    public class ReplayFrame
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int TimeDiff { get; set; }
        public int Time { get; set; }
        public StandardKeys StandardKeys { get; set; }
        public TaikoKeys TaikoKeys { get; set; }
        public CatchKeys CatchKeys { get; set; }
        public ManiaKeys ManiaKeys { get; set; }
    }
}