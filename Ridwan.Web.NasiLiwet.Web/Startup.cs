using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ridwan.Web.NasiLiwet.Web.Startup))]
namespace Ridwan.Web.NasiLiwet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
