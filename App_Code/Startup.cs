using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarageManagement.Startup))]
namespace GarageManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
