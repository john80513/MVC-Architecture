using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AP.Web.Startup))]
namespace AP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
