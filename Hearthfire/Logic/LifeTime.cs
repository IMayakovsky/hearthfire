using System;

namespace Hearthfire.Logic
{
    public class LifeTime
    {
        public static readonly byte ALL_TIME = 24;

        private DateTime _date;

        public Action<string> TimeWasChanged;

        public int Hour => _date.Hour;

        public long Ticks => _date.Ticks;

        public DayOfWeek DayOfWeek => _date.DayOfWeek;

        public string DateAndTimeToString => _date.ToString("dddd, MMM dd yyyy") + ", " + HoursToString;

        public string DateToString => _date.ToString("MM dd yy");

        public string HoursToString => _date.ToString("HH:mm");

        public LifeTime(long ticks)
        {
            _date = new DateTime(ticks);
        }

        public void Increase(int hours = 1)
        {
            _date = _date.AddHours(hours);
           TimeWasChanged?.Invoke(DateAndTimeToString);
        }
    }
}
