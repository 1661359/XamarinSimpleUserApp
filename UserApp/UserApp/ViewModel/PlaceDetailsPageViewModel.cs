using PropertyChanged;
using UserApp.Services;
using UserApp.Shared.Models;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlaceDetailsPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;
        public PlaceDetails PlaceDetails
        {
            get;
            set;
        }

        public PlaceDetailsPageViewModel(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public void LoadPlaceDetails(string placeName)
        {
            PlaceDetails = placeService.GetPlaceDetails(placeName);
        }
    }
}
