using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPC.Startup))]
namespace TPC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
