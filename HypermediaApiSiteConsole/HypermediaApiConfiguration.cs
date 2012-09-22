using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole
{
    public class HypermediaApiConfiguration
    {
        public static HttpSelfHostConfiguration ConfigureSite(string baseAddress)
        {
            var config = new HttpSelfHostConfiguration(baseAddress);

            config.Formatters.Add(new ViewEngineFormatter(new RazorViewEngine()));
            config.Formatters.Add(new PlainTextFormatter());

            config.MessageHandlers.Add(new W3CLogger("web.log"));

            config.Routes.MapHttpRoute("css", "css/{name}", new { controller = "Stylesheets" });
            config.Routes.MapHttpRoute("js", "js/{name}", new { controller = "Javascript" });
            config.Routes.MapHttpRoute("default", "{controller}", new { controller = "Home" });

            return config;
        }
    }
}
