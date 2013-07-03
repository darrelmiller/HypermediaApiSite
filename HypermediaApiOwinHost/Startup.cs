using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HypermediaApiContent;
using Owin;
using Owin.Types;


namespace HypermediaApiOwinHost {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            var addresses = app.Properties["host.Addresses"] as List<IDictionary<string, object>>;
            addresses.Add(SplitUri(new Uri("http://www.hypermediaapi.com")));

           //// MyInstanceMiddleware instance = new MyInstanceMiddleware();
           //// app.Use(instance, "Instance of MyInstanceMiddleware");
           // app.UseType<MyTypeMiddleware>("UseType MyTypeMiddleware");

            
            var config = new HttpConfiguration();
            HypermediaApiConfiguration.ConfigureSite(config);
            app.UseHttpServer(new HttpServer(config));



        }

        // Invoked once per request.
        public Task Invoke(OwinRequest request, OwinResponse response) {
            var tcs = new TaskCompletionSource<OwinResponse>();
          //  response.AddHeader("Tavis", "Darrel was here.");
            tcs.SetResult(response);

            return tcs.Task;
        }


        public Dictionary<string, object> SplitUri(Uri uri)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>()
      {
        {
          "scheme",
          (object) (uri.Scheme)
        },
        {
          "host",
          (object) (uri.Host)
        },
        {
          "port",
          (object) uri.Port.ToString()
        },
        {
          "path",
          (object) (uri.AbsolutePath ?? string.Empty)
        }
      };
            return dictionary;
        }

    }
    


    public class MyInstanceMiddleware
    {
        private AppFunc _next;
        private string _breadcrumb;


        public MyInstanceMiddleware()
        {
        }


        public void Initialize(AppFunc next, string breadcrumb)
        {
            _next = next;
            _breadcrumb = breadcrumb;
        }


        public Task Invoke(IDictionary<string, object> environment)
        {
           
            return _next(environment);
        }
    }

    public class MyTypeMiddleware
    {
        private readonly AppFunc _next;
        private readonly string _breadcrumb;


        public MyTypeMiddleware(AppFunc next, string breadcrumb)
        {
            _next = next;
            _breadcrumb = breadcrumb;
        }


        public Task Invoke(IDictionary<string, object> environment)
        {
//            Helpers.AddBreadCrumb(environment, _breadcrumb);
            return _next(environment);
        }
    }

}