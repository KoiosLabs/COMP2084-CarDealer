using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp2084_CarDealer.Startup))]
namespace Comp2084_CarDealer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
