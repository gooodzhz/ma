using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MA.Web.Startup))]
namespace MA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
