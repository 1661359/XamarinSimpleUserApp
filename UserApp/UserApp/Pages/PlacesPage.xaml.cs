using UserApp.Common.Behaviors;
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
            //ViewModel.CleanSelectedPlaceCommand.Execute(null);

            //ListView.Behaviors.Add(new EventToCommandBehavior()
            //{
            //    Command = ViewModel.ShowDetailsCommand,
            //    EventName = "ItemSelected"
            //});

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //ListView.Behaviors.Clear();
        }
    }
}
