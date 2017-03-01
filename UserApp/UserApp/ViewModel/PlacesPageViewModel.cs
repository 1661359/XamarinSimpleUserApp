using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using UserApp.Helpers;
using UserApp.Pages;
using UserApp.Services;
using Place = UserApp.Shared.Models.Place;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlacesPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;

        public List<Place> Places
        {
            get;
            set;
        }

        public Place SelectedPlace
        {
            get;
            set;
        }

        public PlacesPageViewModel(IPlaceService placeService)
        {
            this.placeService = placeService;
            Places = placeService.GetPlaces().ToList();
        }

        public async Task NavigateToDetails()
        {
            await NavigationHelper.GetPagesNavigation().PushAsync(new PlaceDetailsPage(SelectedPlace.Name));
            SelectedPlace = null;
        }
    }
}
