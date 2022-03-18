using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteBanSach4.Startup))]
namespace WebSiteBanSach4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
