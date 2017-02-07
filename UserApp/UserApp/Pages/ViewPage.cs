using Autofac;
using UserApp.ViewModel;
using Xamarin.Forms;

namespace UserApp.Pages
{
    public class ViewPage<T>: ContentPage where T:IViewModel
    {
        private readonly T viewModel;

        public T ViewModel => viewModel;

        public ViewPage()
        {
            using (var scope = AppContainer.Container.BeginLifetimeScope())
            {
                viewModel = AppContainer.Container.Resolve<T>();
            }
            BindingContext = viewModel;
        }
    }
}
