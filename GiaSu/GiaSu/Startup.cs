using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiaSu.Startup))]
namespace GiaSu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
