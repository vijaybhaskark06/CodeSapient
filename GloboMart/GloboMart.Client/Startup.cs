using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GloboMart.Client.Startup))]
namespace GloboMart.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
