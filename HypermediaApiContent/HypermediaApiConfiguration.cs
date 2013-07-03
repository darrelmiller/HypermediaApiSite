using System.IO;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using HypermediaApiContent.Model;
using HypermediaApiContent.Tools;
using HypermediaApiSiteConsole;
using HypermediaApiSiteConsole.Tools;
using Microsoft.Practices.Unity;

namespace HypermediaApiContent
{
    public class HypermediaApiConfiguration
    {
        public static HttpConfiguration ConfigureSite(HttpConfiguration config) {

            config.EnableSystemDiagnosticsTracing();
            config.Formatters.Clear();
            config.Formatters.Add(new ViewEngineFormatter(new RazorViewEngine()));
            config.Formatters.Add(new PlainTextFormatter());
            config.Formatters.Add(new ODataMediaTypeFormatter());

            

            config.MessageHandlers.Add(new W3CLogger(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "web.log")));
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<InfoRepository>(new ContainerControlledLifetimeManager());

            config.DependencyResolver = new UnityResolver(unityContainer);

            ThreadPool.SetMinThreads(50, 4);

            config.Routes.MapHttpRoute("css", "css/{name}", new { controller = "Stylesheets" });
            config.Routes.MapHttpRoute("js", "js/{name}", new { controller = "Javascript" });
            config.Routes.MapHttpRoute("img", "img/{name}", new { controller = "Images" });
            config.Routes.MapHttpRoute("defaultext", "{controller}.{ext}", new { ext = RouteParameter.Optional });
            config.Routes.MapHttpRoute("default", "{controller}", new { controller = "Home" });

            return config;
        }
    }
}
