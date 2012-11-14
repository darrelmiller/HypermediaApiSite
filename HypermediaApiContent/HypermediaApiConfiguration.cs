using System.Web.Http;
using HypermediaApiContent.Tools;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiContent
{
    public class HypermediaApiConfiguration
    {
        public static HttpConfiguration ConfigureSite(HttpConfiguration config)
        {
            

            config.Formatters.Add(new ViewEngineFormatter(new RazorViewEngine()));
            config.Formatters.Add(new PlainTextFormatter());

          //  config.MessageHandlers.Add(new W3CLogger("web.log"));

            config.Routes.MapHttpRoute("css", "css/{name}", new { controller = "Stylesheets" });
            config.Routes.MapHttpRoute("js", "js/{name}", new { controller = "Javascript" });
            config.Routes.MapHttpRoute("api", "{controller}", new { controller = "Home" });

            return config;
        }
    }
}
