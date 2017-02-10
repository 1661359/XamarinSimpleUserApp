using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class MenuPageBase : ViewPage<MenuPageViewModel> { }

    public partial class MenuPage : MenuPageBase
    {
        public ListView ListView => MasterPageListView;

        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
