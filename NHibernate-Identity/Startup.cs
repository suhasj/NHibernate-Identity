using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernate_Identity.Startup))]
namespace NHibernate_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
