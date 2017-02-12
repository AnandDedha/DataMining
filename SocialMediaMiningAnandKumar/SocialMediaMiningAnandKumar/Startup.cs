using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialMediaMiningAnandKumar.Startup))]
namespace SocialMediaMiningAnandKumar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
