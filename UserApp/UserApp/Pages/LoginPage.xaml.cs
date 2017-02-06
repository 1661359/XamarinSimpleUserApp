using System;
using System.Threading.Tasks;
using UserApp.ViewModel;

namespace UserApp.Pages
{
    public  class LoginPageBase : ViewPage<LoginViewModel> { }
    public partial class LoginPage : LoginPageBase
    {
        public LoginPage()
        {            
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await NavigateToMainPageWhenLoggedIn();
        }

        private async void LogInButtonClicked(object sender, EventArgs e)
        {
            await Task.Run(() => viewModel.DoLoginCommand.Execute(viewModel));
            await NavigateToMainPageWhenLoggedIn();
        }

        private async Task NavigateToMainPageWhenLoggedIn()
        {
            if (viewModel.IsLoggedIn)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
