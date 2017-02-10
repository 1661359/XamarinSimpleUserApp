using System;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class PageA : ContentPage
    {
        public PageA()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new PageB());
        }
    }
}
