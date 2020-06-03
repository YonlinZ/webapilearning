using IdentityServer3.AccessTokenValidation;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using IdentityServerSample;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]
namespace IdentityServerSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {

                Authority = "http://localhost:8848",
                RequiredScopes = new[] { "Api1", "Api2" },
                ValidationMode = ValidationMode.ValidationEndpoint,
            });
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);

            var identityServerOptions = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.GetClients())
                .UseInMemoryScopes(Scopes.GetScopes())
                .UseInMemoryUsers(new List<InMemoryUser>()),
                RequireSsl = false
            };

            app.UseIdentityServer(identityServerOptions);


        }

    }
}
