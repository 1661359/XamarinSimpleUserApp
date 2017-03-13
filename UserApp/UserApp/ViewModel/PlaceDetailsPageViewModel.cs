using System;
using System.Linq;
using PropertyChanged;
using UserApp.Common;
using UserApp.Services;
using UserApp.Shared.Models;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlaceDetailsPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;
        private readonly IGeoService geoService;
        public NotifyTaskCompletion<PlaceDetails> PlaceDetails
        {
            get;
            set;
        }

        public double Distance
        {
            get;
            set;
        }

        public WorkingTime WeekdaysTime
        {
            get;
            set;
        }

        public WorkingTime SaturdayTime
        {
            get;
            set;
        }
        public WorkingTime SundayTime
        {
            get;
            set;
        }

        public Guid PlaceId
        {
            get;
            set;
        }

        public PlaceDetailsPageViewModel(IPlaceService placeService, IGeoService geoService)
        {
            this.placeService = placeService;
            this.geoService = geoService;
        }

        public void LoadPlaceDetails()
        {
            PlaceDetails = new NotifyTaskCompletion<PlaceDetails>(placeService.GetPlaceDetails(PlaceId));
            PlaceDetails.OnResultReturned += PlaceDetails_OnResultReturned;
        }

        private void PlaceDetails_OnResultReturned(object sender, EventArgs e)
        {
            PlaceDetails.OnResultReturned -= PlaceDetails_OnResultReturned;
            Distance = geoService.GetDistanceTo(PlaceDetails.Result.Address);
            WeekdaysTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek != DayOfWeek.Saturday || x.DayOfWeek != DayOfWeek.Sunday);
            SaturdayTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek == DayOfWeek.Saturday);
            SundayTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}
