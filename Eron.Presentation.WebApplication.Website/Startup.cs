using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Eron.Presentation.WebApplication.Website.Startup))]

namespace Eron.Presentation.WebApplication.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
