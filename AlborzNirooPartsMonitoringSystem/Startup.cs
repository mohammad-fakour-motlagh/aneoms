using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlborzNirooPartsMonitoringSystem.Startup))]
namespace AlborzNirooPartsMonitoringSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}