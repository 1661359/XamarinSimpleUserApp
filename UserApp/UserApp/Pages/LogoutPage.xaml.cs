using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class LogoutPageBase : ViewPage<LogoutPageViewModel> { }

    public partial class LogoutPage : LogoutPageBase
    {
        public LogoutPage()
        {
            InitializeComponent();      
        }
    }
}
