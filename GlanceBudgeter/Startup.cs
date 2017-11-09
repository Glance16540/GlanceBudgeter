using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlanceBudgeter.Startup))]
namespace GlanceBudgeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
