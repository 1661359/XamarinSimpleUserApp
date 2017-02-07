using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class MainPageBase : ViewPage<MainPageViewModel> { }

    public partial class MainPage : MainPageBase
    {
        public MainPage()
        {
            InitializeComponent();          
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadUserNameCommand.Execute(ViewModel);
        }
    }
}
