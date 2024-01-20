using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDOTASK1.Startup))]
namespace BDOTASK1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
