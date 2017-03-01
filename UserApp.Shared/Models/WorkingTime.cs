using System;

namespace UserApp.Shared.Models
{
    public class WorkingTime
    {
        public DayOfWeek DayOfWeek
        {
            get;
            set;
        }

        public TimeSpan StartTime
        {
            get;
            set;
        }
        public TimeSpan EndTime
        {
            get;
            set;
        }

        
    }
}