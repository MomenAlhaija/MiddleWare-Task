using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDO_Task_1.Startup))]
namespace BDO_Task_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
