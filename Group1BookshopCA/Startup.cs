using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Group1BookshopCA.Startup))]
namespace Group1BookshopCA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
