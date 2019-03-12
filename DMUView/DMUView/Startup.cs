using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMUView.Startup))]
namespace DMUView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
