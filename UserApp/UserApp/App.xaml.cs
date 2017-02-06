using Xamarin.Forms;
using UserApp.Pages;

namespace UserApp
{
    public partial class App : Application
    {
        public App(AppSetup setup)
        {
            InitializeComponent();

            AppContainer.Container = setup.CreateContainer();

            MainPage = new NavigationPage(new LoginPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            // Handle when your app resumes
            if (!Current.Properties.ContainsKey("UserName"))
            {
                await MainPage.Navigation.PopToRootAsync(false);
                await MainPage.Navigation.PushAsync(new LoginPage());
            }
        }
    }
}
