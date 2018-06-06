using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab26_ASP.NET_IDENTITY.Startup))]
namespace Lab26_ASP.NET_IDENTITY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
