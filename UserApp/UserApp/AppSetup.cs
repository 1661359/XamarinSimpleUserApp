using Autofac;
using UserApp.Services;
using UserApp.Services.ApiWrapper;
using UserApp.ViewModel;


namespace UserApp
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder builder)
        {
            RegisterViewModels(builder);
            builder.RegisterInstance<IApiProvider>(new ApiProvider());
            builder.RegisterType<PlaceService>().As<IPlaceService>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<GeoService>().As<IGeoService>();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<LogoutPageViewModel>();
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<MenuPageViewModel>();
            builder.RegisterType<PlacesPageViewModel>().SingleInstance();
            builder.RegisterType<PlaceDetailsPageViewModel>();

        }
    }
}
