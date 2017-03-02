using System;
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
        public NotifyTaskCompletion<PlaceDetails> PlaceDetails
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
        }
    }
}
