using System;
using Autofac;
using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class MainDetailedPage : MasterDetailPage
    {
        private readonly MainDetailedPageViewModel viewModel;

        public MainDetailedPage()
        {
            InitializeComponent();
            UserAppMasterPage.ListView.ItemSelected += ListViewOnItemSelected;

            using (AppContainer.Container.BeginLifetimeScope())
            {
                viewModel = AppContainer.Container.Resolve<MainDetailedPageViewModel>();
            }
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
                UserAppMasterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
