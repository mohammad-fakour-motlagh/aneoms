using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlborzNirooEnginesObservationAndMonitoringSystem.Startup))]
namespace AlborzNirooEnginesObservationAndMonitoringSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}