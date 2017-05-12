
using System.Web.Http;
using CS.OAuthDemo;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace CS.OAuthDemo
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);



        }
    }


    /*
     
     
    this class will be fired once our server starts, notice the “assembly” attribute which states which class to fire on start-up. The “Configuration” method accepts parameter of type “IAppBuilder” this parameter will be supplied by the host at run-time. This “app” parameter is an interface which will be used to compose the application for our Owin server.
     
     */
}