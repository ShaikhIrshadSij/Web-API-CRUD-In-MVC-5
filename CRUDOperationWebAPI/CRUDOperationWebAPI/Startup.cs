using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDOperationWebAPI.Startup))]
namespace CRUDOperationWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
