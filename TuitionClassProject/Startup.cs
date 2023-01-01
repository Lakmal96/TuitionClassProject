using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuitionClassProject.Startup))]
namespace TuitionClassProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
