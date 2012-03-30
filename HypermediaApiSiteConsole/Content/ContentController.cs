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


        public HttpResponseMessage Get(string name)
        {
            var viewStream = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), name + "View.cshtml");

            var view = new View(viewStream, new RootModel() {Site = "Hypermedia API"});

            var content = view.CreateContent();
            content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            var response = new HttpResponseMessage
                               {
                                   Content = content,
                                   Headers =
                                       {
                                           CacheControl = new CacheControlHeaderValue()
                                                              {
                                                                  MaxAge = new TimeSpan(1, 0, 0)
                                                              }
                                       }
                               };

            return response;
        }
    }
}
