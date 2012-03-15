using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using HypermediaApiSiteConsole.Tools;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace HypermediaApiSiteConsole.Content
{
    public class ContentController : ApiController
    {
        private readonly IViewEngine _viewEngine;

        public ContentController(IViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        public HttpResponseMessage Get(string name)
        {
            var viewStream = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), name + "View.cshtml");

            var content = new HtmlContent<RootModel>(_viewEngine, viewStream, new RootModel() { Site = "Hypermedia API" });

            var response = new HttpResponseMessage() { Content = content };
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = new TimeSpan(1, 0, 0)
            };
            return response;
        }
    }
}
