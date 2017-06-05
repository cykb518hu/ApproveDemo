using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FutureDemo.Startup))]
namespace FutureDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
