using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class LoginPageBase : ViewPage<LoginViewModel> { }
    public partial class LoginPage : LoginPageBase
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void UserNameEntry_OnFocused(object sender, FocusEventArgs e)
        {
            ViewModel.IsMessageVisible = false;
        }
    }
}
