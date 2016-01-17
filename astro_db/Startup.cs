using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(astro_db.Startup))]
namespace astro_db
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
