using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_BDO_MVC.Startup))]
namespace Task_BDO_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
