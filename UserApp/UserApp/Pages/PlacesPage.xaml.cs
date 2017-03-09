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
    }
}
