
using System;
using System.Web.Http;
using CS.OAuthDemo;
using CS.OAuthDemo.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace CS.OAuthDemo
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {


            ConfigureOAuth(app);


            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);


        }


        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Provider = new SimpleAuthorizationServerProvider()
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }





    }


    /*
     
     
    this class will be fired once our server starts, notice the “assembly” attribute which states which class to fire on start-up. The “Configuration” method accepts parameter of type “IAppBuilder” this parameter will be supplied by the host at run-time. This “app” parameter is an interface which will be used to compose the application for our Owin server.
     
     */
}