using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UserApp.Api.Startup))]

namespace UserApp.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
