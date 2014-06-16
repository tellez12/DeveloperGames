using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeveloperGames.WebUI.Startup))]
namespace DeveloperGames.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
