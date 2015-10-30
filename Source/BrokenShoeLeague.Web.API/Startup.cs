using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BrokenShoeLeague.Web.API.Startup))]

namespace BrokenShoeLeague.Web.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
