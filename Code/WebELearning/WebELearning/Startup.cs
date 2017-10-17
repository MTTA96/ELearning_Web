using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebELearning.Startup))]
namespace WebELearning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
