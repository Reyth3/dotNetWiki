using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dotNetWiki.Startup))]
namespace dotNetWiki
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
