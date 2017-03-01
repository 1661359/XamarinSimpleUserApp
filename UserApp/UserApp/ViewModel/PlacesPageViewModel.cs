using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using UserApp.Helpers;
using UserApp.Helpers.Mappers;
using UserApp.Pages;
using UserApp.Services;
using UserApp.Shared.ViewModels;
using Place = UserApp.Shared.Models.Place;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlacesPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;

        public List<PlaceViewModel> Places
        {
            get;
            set;
        }

        public PlaceViewModel SelectedPlace
        {
            get;
            set;
        }

        public PlacesPageViewModel(IPlaceService placeService)
        {
            this.placeService = placeService;
            Places = placeService.GetPlaces().Select(PlaceMapper.GetPlaceViewModel).ToList();
        }
        
        public async Task NavigateToDetails()
        {
            await NavigationHelper.GetPagesNavigation().PushAsync(new PlaceDetailsPage(SelectedPlace.Name));
            SelectedPlace = null;
        }
    }
}
