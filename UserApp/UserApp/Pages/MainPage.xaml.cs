using System;
using UserApp.Common;
using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class MainPage : MasterDetailPage
    {
        private readonly MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            MenuPage.ListView.ItemSelected += ListViewOnItemSelected;

            viewModel = AppContainer.ResolveViewModel<MainPageViewModel>();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            viewModel.LoadLoginPageWhenNotLogged();
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MenuPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
