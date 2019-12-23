using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantOrderApp.Startup))]
namespace RestaurantOrderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
