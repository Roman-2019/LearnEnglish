using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LEnglish.Startup))]
namespace LEnglish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
