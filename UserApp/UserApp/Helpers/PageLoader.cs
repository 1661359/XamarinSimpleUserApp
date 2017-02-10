using UserApp.Pages;
using Xamarin.Forms;

namespace UserApp.Helpers
{
    public static class PageLoader
    {
        public static void ShowMainPage(this Application application)
        {
            var mainPage = new MainPage();
            application.MainPage = mainPage;
            App.MasterDetailPage = mainPage;
        }

        public static void ShowLoginPage(this Application application)
        {
            application.MainPage = new LoginPage();
        }
    }
}
