using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eron.web.Startup))]
namespace Eron.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
