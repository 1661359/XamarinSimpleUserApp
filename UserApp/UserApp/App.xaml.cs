using UserApp.Helpers;
using Xamarin.Forms;

namespace UserApp
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage;


        public App(AppSetup setup)
        {
            InitializeComponent();

            AppContainer.Container = setup.CreateContainer();

            this.ShowMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
