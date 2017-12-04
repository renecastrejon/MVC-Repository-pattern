using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Dependency_Injection.Startup))]
namespace MVC_Dependency_Injection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
