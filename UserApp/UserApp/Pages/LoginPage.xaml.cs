using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class LoginPageBase : ViewPage<LoginViewModel> { }
    public partial class LoginPage : LoginPageBase
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
