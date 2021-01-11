using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigStonks.Startup))]
namespace BigStonks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
