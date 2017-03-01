﻿using System.Collections.Generic;

namespace UserApp.Shared.Models
{
    public class Place
    {
        public string Name
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public double AverageCost
        {
            get;
            set;
        }

        public IEnumerable<WorkingTime> WorkDays
        {
            get;
            set;
        }
    }
}