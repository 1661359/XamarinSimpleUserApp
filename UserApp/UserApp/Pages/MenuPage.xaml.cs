using System.Collections.Generic;
using UserApp.Common;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView => MasterPageListView;

        public MenuPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem {TargetType = typeof(PageA), Title = "PageA"},
                new MasterPageItem {TargetType = typeof(PageB), Title = "PageB"},
                new MasterPageItem {TargetType = typeof(LogoutPage), Title = "Logout page"},
            };
            MasterPageListView.ItemsSource = masterPageItems;
        }
    }
}
