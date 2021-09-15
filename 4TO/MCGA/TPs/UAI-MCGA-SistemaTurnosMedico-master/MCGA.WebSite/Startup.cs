using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCGA.WebSite.Startup))]
namespace MCGA.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
