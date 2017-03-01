using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class PlacesPageBase : ViewPage<PlacesPageViewModel> { }
    public partial class PlacesPage : PlacesPageBase
    {
        public PlacesPage()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            await ViewModel.NavigateToDetails();
        }


    }
}
