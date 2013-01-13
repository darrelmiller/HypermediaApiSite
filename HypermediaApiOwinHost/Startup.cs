using System.Web.Http;
using HypermediaApiContent;
using Owin;

namespace HypermediaApiOwinHost {
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            var config = new HttpConfiguration();
            HypermediaApiConfiguration.ConfigureSite(config);
            app.UseHttpServer(new HttpServer(config));
           
        }
    }
}