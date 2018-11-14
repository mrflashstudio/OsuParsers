using OsuParsers.Enums;
using OsuParsers.Storyboards.Interfaces;

namespace OsuParsers.Storyboards.Commands
{
    public class Command<T> : ICommand
    {
        public Easing Easing { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public T StartValue;
        public T EndValue;

        public Command(Easing easing, int startTime, int endTime, T startValue, T endValue)
        {
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            StartValue = startValue;
            EndValue = endValue;
        }
    }
}
