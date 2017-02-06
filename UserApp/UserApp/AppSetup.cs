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
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterInstance<IApiProvider>(new ApiProvider());
            builder.RegisterInstance(new AppSessionConfig());
        }
    }
}
