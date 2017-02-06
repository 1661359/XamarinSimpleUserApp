using System;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void LogOutButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(false);
        }
    }
}
