using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitHub1.Startup))]
namespace GitHub1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
