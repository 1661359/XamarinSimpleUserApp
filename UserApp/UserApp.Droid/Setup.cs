using Autofac;

namespace UserApp.Droid
{
    class Setup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            base.RegisterDependencies(builder);
        }
    }
}