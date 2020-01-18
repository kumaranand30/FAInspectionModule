using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FAInspectionModuleMVC.Startup))]
namespace FAInspectionModuleMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
