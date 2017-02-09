using System.Collections.Generic;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView => MasterPageListView;

        public MasterPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem {TargetType = typeof(PageA), Title = "PageA"},
                new MasterPageItem {TargetType = typeof(PageB), Title = "PageB"},
                new MasterPageItem {TargetType = typeof(MainPage), Title = "MainPage"},

            };
            MasterPageListView.ItemsSource = masterPageItems;
        }
    }
}
