using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBD_Project.Startup))]
namespace SBD_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
