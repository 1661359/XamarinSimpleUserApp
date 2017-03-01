using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class PlaceDetailsPageBase : ViewPage<PlaceDetailsPageViewModel> { }
    public partial class PlaceDetailsPage : PlaceDetailsPageBase
    {
        public PlaceDetailsPage()
        {
            InitializeComponent();
        }

        public PlaceDetailsPage(string name) : this()
        {
            ViewModel.LoadPlaceDetails(name);
        }
    }
}
