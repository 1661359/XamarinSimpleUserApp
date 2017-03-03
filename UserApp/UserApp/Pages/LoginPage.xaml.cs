using IronKit.Commanding;
using UserApp.Common.Behaviors;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UserNameEntry.Behaviors.Add(new EventToCommandBehavior {EventName = "OnFocused", Command = new Command(ViewModel.HideMessage)});
        }

        protected override void OnDisappearing()
        {
            UserNameEntry.Behaviors.Clear();
            base.OnDisappearing();
        }
    }
}
