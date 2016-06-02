using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewspaperMailRegister.Startup))]
namespace NewspaperMailRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
