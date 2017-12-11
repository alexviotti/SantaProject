using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaProject.Startup))]
namespace SantaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
