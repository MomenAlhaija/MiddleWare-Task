using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task1_BDO.Startup))]
namespace Task1_BDO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
