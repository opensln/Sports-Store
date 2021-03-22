using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGDFiteness4.Startup))]
namespace AGDFiteness4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
