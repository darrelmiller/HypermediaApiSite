using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Services;
using HypermediaApiSiteConsole.Tools;
using Microsoft.Practices.Unity;

namespace HypermediaApiSiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new HttpSelfHostConfiguration("http://www.hypermediaapi.com");

            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IViewEngine, RazorViewEngine>(new ContainerControlledLifetimeManager());
            

            // By convention the RazorViewEngine looks for a template in the same folder as the Model type. e.g RootModel looks for RootView in the same folder
            config.Formatters.Add(new ViewEngineFormatter(new RazorViewEngine()));

            config.ServiceResolver.SetResolver(new UnityResolver(unityContainer));

            config.Routes.MapHttpRoute("default", "{controller}",new {controller="Root"});
            config.Routes.MapHttpRoute("stylesheets", "Stylesheets/{name}", new { controller = "Stylesheets" });
            config.Routes.MapHttpRoute("content", "Content/{name}", new { controller = "Content" });

            var host = new HttpSelfHostServer(config);

            host.OpenAsync().Wait();

            Console.WriteLine("Press enter to shutdown service");
            Console.ReadLine();

            host.CloseAsync().Wait();


        }
    }

    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            object service = null;
            try
            {
                service = _unityContainer.Resolve(serviceType);
            } catch
            {
                
            }
            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return (IEnumerable<object>)_unityContainer.Resolve(typeof(IEnumerable<>).MakeGenericType(new[] { serviceType }));
            }
            catch
            {

            }
            return new List<object>();
        }
    }
}
