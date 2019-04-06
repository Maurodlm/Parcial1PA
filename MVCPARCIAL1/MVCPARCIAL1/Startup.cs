using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPARCIAL1.Startup))]
namespace MVCPARCIAL1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
