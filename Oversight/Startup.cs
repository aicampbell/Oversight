using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oversight.Startup))]
namespace Oversight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
