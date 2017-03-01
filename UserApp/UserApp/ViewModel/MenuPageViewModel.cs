using System.Collections.Generic;
using PropertyChanged;
using UserApp.Common;
using UserApp.Helpers;

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
            MenuItems = NavigationHelper.GetMenuItems();
        }
    }
}
