namespace OsuParsers.Beatmaps.Sections.Events
{
    public class BeatmapBreakEvent
    {
        public int StartTime { get; private set; }
        public int EndTime { get; private set; }

        public BeatmapBreakEvent(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
