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
            LoadPlaces();
        }

        public void LoadPlaces()
        {
            var getPlacesTaskCompletion = new NotifyTaskCompletion<IEnumerable<Place>>(placeService.GetPlaces());
            getPlacesTaskCompletion.OnResultReturned += PlacesReturned;   
        }

        private void PlacesReturned(object sender, EventArgs e)
        {
            var taskCompletion = (NotifyTaskCompletion<IEnumerable<Place>>) sender;
            var places = taskCompletion.Result;
            Places = places?.Select(PlaceMapper.MapToPlaceViewModel).ToList();
        }

        public async Task NavigateToDetails()
        {           
            await NavigationHelper.GetPagesNavigation().PushAsync(new PlaceDetailsPage(SelectedPlace.Id));
            SelectedPlace = null;
        }
    }
}
