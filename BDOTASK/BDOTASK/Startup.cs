using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDOTASK.Startup))]
namespace BDOTASK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
