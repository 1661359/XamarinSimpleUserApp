using System.Collections.Generic;
using PropertyChanged;
using UserApp.Common;
using UserApp.Pages;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MenuPageViewModel : IViewModel
    {
        public List<MasterPageItem> MenuItems
        {
            get;
            set; 
        }

        public MenuPageViewModel()
        {
            MenuItems = new List<MasterPageItem>
            {
                new MasterPageItem {TargetType = typeof(ProductPage), Title = "Products"},
                new MasterPageItem {TargetType = typeof(PageB), Title = "PageB"},
                new MasterPageItem {TargetType = typeof(LogoutPage), Title = "Logout page"},
            };
        }
    }
}
