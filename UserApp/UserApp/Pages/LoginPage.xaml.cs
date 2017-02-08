using System;
using System.Globalization;
using IronKit.Validation;
using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class LoginPageBase : ViewPage<LoginViewModel> { }
    public partial class LoginPage : LoginPageBase
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await ViewModel.NavigateToMainPageWhenLoggedIn();
        }

        private void UserNameEntry_OnFocused(object sender, FocusEventArgs e)
        {
            ViewModel.IsMessageVisible = false;
        }
    }

    public class ValidationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var validationState = (ValidationState) ((Entry)parameter).GetValue(Validation.ValidationStateProperty);
            return validationState == ValidationState.Valid;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
