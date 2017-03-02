using System;
using System.Linq;
using PropertyChanged;
using UserApp.Common;
using UserApp.Helpers.Mappers;
using UserApp.Services;
using UserApp.Shared.Models;
using UserApp.Shared.ViewModels;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlaceDetailsPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;
        public NotifyTaskCompletion<PlaceDetails> PlaceDetails
        {
            get;
            set;
        }

        public PlaceViewModel PlaceViewModel
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


        public PlaceDetailsPageViewModel(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public void LoadPlaceDetails(Guid id)
        {
            PlaceDetails = new NotifyTaskCompletion<PlaceDetails>(placeService.GetPlaceDetails(id));
            PlaceDetails.OnResultReturned += PlaceDetails_OnResultReturned;
        }

        private void PlaceDetails_OnResultReturned(object sender, EventArgs e)
        {
            PlaceViewModel = PlaceMapper.MapToPlaceViewModel(PlaceDetails.Result);
            WeekdaysTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek != DayOfWeek.Saturday || x.DayOfWeek != DayOfWeek.Sunday);
            SaturdayTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek == DayOfWeek.Saturday);
            SundayTime = PlaceDetails.Result.WorkDays?.FirstOrDefault(x => x.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}
