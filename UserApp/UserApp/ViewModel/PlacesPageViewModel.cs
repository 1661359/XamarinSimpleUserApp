using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using UserApp.Common;
using UserApp.Helpers;
using UserApp.Helpers.Mappers;
using UserApp.Pages;
using UserApp.Services;
using UserApp.Shared.Models;
using UserApp.Shared.ViewModels;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlacesPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;
        private readonly IGeoService geoService;
        private NotifyTaskCompletion<IEnumerable<Place>> getPlacesTaskCompletion;

        public List<PlaceViewModel> Places
        {
            get;
            private set;
        }

        public string ZipCodeFilter
        {
            get;
            set;
        }

        public bool IsWaitPlaces
        {
            get;
            set;
        }

        public bool IsSelectPlaceEnabled
        {
            get;
            set;
        }

        public PlacesPageViewModel(IPlaceService placeService, IGeoService geoService)
        {
            this.placeService = placeService;
            this.geoService = geoService;
            IsSelectPlaceEnabled = true;           
        }

        public void LoadPlaces()
        {
            IsWaitPlaces = true;
            getPlacesTaskCompletion = new NotifyTaskCompletion<IEnumerable<Place>>(placeService.GetPlaces(
                new Place
                {
                    ZipCode = ZipCodeFilter
                }));
            getPlacesTaskCompletion.OnResultReturned += PlacesReturned;
        }

        private void PlacesReturned(object sender, EventArgs e)
        {
            getPlacesTaskCompletion.OnResultReturned -= PlacesReturned;
            IsWaitPlaces = false;
            var taskCompletion = (NotifyTaskCompletion<IEnumerable<Place>>)sender;
            var places = taskCompletion.Result;
            Places = places?.Select(GetPlaceViewModel).ToList();
        }

        private PlaceViewModel GetPlaceViewModel(Place place)
        {
            var viewModel = PlaceMapper.MapToPlaceViewModel(place);
            viewModel.Distance = geoService.GetDistanceTo(place.Address);
            return viewModel;
        }

        public async Task ShowDetails(PlaceViewModel selectedPlace)
        {
            IsSelectPlaceEnabled = false;
            if (selectedPlace != null)
                await NavigationHelper.GetPagesNavigation().PushAsync(new PlaceDetailsPage(selectedPlace.Id));
            IsSelectPlaceEnabled = true;
        }
    }
}
