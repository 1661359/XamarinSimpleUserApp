using System;

namespace UserApp.Shared.ViewModels
{
    public class PlaceViewModel
    {
        public string Name
        {
            get;
            set;
        }

        public Guid Id
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

        public double Distance
        {
            get;
            set;
        }

        public string WorkingTimeToday
        {
            get;
            set;
        }
    }
}