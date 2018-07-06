using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalePizza.Startup))]
namespace SalePizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
