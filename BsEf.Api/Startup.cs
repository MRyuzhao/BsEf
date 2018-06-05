using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BsEf.Api.Startup))]

namespace BsEf.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
