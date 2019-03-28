using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMUVIews.Startup))]
namespace DMUVIews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
