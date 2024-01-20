using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_BDO.Startup))]
namespace Task_BDO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
