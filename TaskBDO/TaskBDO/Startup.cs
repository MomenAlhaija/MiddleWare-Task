using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskBDO.Startup))]
namespace TaskBDO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
