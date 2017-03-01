using System.Collections.Generic;
using UserApp.Common;
using UserApp.Pages;
using Xamarin.Forms;

namespace UserApp.Helpers
{
    public class NavigationHelper
    {
        public static INavigation GetPagesNavigation()
        {
            return App.MasterDetailPage.Detail.Navigation;
        }

        public static List<MasterPageItem> GetMenuItems()
        {
            return new List<MasterPageItem>
            {
                new MasterPageItem {TargetType = typeof(PlacesPage), Title = "Places"},
                new MasterPageItem {TargetType = typeof(LogoutPage), Title = "Logout page"},
            };
        }
    }
}