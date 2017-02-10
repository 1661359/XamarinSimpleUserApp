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
            builder.RegisterInstance(new AppSessionConfig());
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<LogoutPageViewModel>().SingleInstance();
            builder.RegisterType<MainPageViewModel>().SingleInstance();
            builder.RegisterType<MenuPageViewModel>().SingleInstance();
        }
    }
}
