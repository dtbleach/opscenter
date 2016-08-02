using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpsPortal.Startup))]
namespace OpsPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
