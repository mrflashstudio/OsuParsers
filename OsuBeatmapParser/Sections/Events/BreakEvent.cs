namespace OsuBeatmapParser.Sections.Events
{
    public class BreakEvent
    {
        public int StartTime { get; private set; }
        public int EndTime { get; private set; }

        public BreakEvent(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
