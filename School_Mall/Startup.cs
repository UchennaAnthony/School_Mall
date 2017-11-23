using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(School_Mall.Startup))]
namespace School_Mall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
