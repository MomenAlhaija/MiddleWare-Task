using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDO_Task.Startup))]
namespace BDO_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
