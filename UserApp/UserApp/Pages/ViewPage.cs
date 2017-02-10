using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class ViewPage<T>: ContentPage where T:IViewModel
    {
        public T ViewModel { get; }

        public ViewPage()
        {
            ViewModel = AppContainer.ResolveViewModel<T>();
            BindingContext = ViewModel;
        }
    }
}
