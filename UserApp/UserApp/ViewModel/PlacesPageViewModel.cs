using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using UserApp.Common;
using UserApp.Helpers;
using UserApp.Helpers.Mappers;
using UserApp.Pages;
using UserApp.Services;
using UserApp.Shared.Models;
using UserApp.Shared.ViewModels;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class PlacesPageViewModel : IViewModel
    {
        private readonly IPlaceService placeService;

        public List<PlaceViewModel> Places
        {
            get;
            private set;
        }

        public ICommand ShowDetailsCommand
        {
            get;
            private set;
        }

        public PlacesPageViewModel(IPlaceService placeService)
        {
            this.placeService = placeService;

            ShowDetailsCommand = new Command<PlaceViewModel>(async (p) => await ShowDetails(p));

            LoadPlaces();
        }

        private void LoadPlaces()
        {
            var getPlacesTaskCompletion = new NotifyTaskCompletion<IEnumerable<Place>>(placeService.GetPlaces());
            getPlacesTaskCompletion.OnResultReturned += PlacesReturned;
        }

        private void PlacesReturned(object sender, EventArgs e)
        {
            var taskCompletion = (NotifyTaskCompletion<IEnumerable<Place>>)sender;
            var places = taskCompletion.Result;
            Places = places?.Select(PlaceMapper.MapToPlaceViewModel).ToList();
        }

        private async Task ShowDetails(PlaceViewModel selectedPlace)
        {
            if (selectedPlace != null)
                await NavigationHelper.GetPagesNavigation().PushAsync(new PlaceDetailsPage(selectedPlace.Id));
        }
    }
}
