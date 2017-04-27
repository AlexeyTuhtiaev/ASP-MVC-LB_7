using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_50331_TUHTIAEV.Startup))]
namespace _50331_TUHTIAEV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
