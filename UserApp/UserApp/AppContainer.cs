using Autofac;
using UserApp.ViewModel;

namespace UserApp
{
    public static class AppContainer
    {
        public static IContainer Container { get; set; }


        public static T ResolveViewModel<T>() where T:IViewModel
        {
            T viewModel;
            using (Container.BeginLifetimeScope())
            {
                viewModel = Container.Resolve<T>();
            }
            return viewModel;
        }
    }
}
