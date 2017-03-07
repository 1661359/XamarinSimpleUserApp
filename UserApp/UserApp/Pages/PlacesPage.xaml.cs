using UserApp.Common.Behaviors;
using UserApp.Common.Converters;
using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class PlacesPageBase : ViewPage<PlacesPageViewModel> { }
    public partial class PlacesPage : PlacesPageBase
    {
        public PlacesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListView.Behaviors.Add(new EventToCommandBehavior()
            {
                Command = ViewModel.ShowDetailsCommand,
                EventName = "ItemSelected",
                Converter = new SelectedItemConverter()
            });
            ZipCodeEntry.Behaviors.Add(new EventToCommandBehavior
            {
                Command = ViewModel.UpdatePlacesCommand,
                EventName = "TextChanged"
            });
        }


        protected override void OnDisappearing()
        {
            ListView.Behaviors.Clear();
            ZipCodeEntry.Behaviors.Clear();

            base.OnDisappearing();
        }
    }
}
