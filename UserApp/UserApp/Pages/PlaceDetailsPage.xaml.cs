using System;
using UserApp.ViewModel;

namespace UserApp.Pages
{
    public class PlaceDetailsPageBase : ViewPage<PlaceDetailsPageViewModel> { }
    public partial class PlaceDetailsPage : PlaceDetailsPageBase
    {
        public PlaceDetailsPage()
        {
            InitializeComponent();
        }

        public PlaceDetailsPage(Guid id) : this()
        {
            ViewModel.PlaceId = id;
        }
    }
}
