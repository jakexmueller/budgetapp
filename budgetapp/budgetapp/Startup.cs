using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(budgetapp.Startup))]
namespace budgetapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
