using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gym_Management.Startup))]
namespace Gym_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
