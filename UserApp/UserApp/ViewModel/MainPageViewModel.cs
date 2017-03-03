using PropertyChanged;
using UserApp.Helpers;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MainPageViewModel : IViewModel
    {
        public MainPageViewModel()
        {
            
        }

        public void LoadLoginPageWhenNotLogged()
        {
            //clear
            //appSessionConfig.LoadAuthorizationResult(new UserAuthorizationViewModel() {AuthorizationAnswer = AuthorizationAnswer.Ok, UserName = "LOL"});
            if (!AppSessionConfig.IsLoggedIn)
                Application.Current.ShowLoginPage();
        }

    }
}
