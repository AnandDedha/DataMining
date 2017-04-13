using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Data_Visualization.Startup))]
namespace Data_Visualization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
