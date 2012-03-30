using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using HypermediaApiSiteConsole.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Encoding = RazorEngine.Encoding;

namespace HypermediaApiSiteConsole
{
    public class RootController : ApiController
    {
        private readonly IViewEngine _viewEngine;

        public RootController(IViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        public View Get()
        {
            var templateStream = this.GetType().Assembly.GetManifestResourceStream(typeof (RootController), "RootView.cshtml");
            
            var siteInfo = new RootModel() {Site = "Hypermedia API"};

            return new View(templateStream,siteInfo);

        }

        
       private StreamContent GetHtmlContent(Stream viewStream, RootModel rootModel, IViewEngine viewEngine)
        {
            Stream contentStream = new MemoryStream();

            

            viewEngine.RenderTo<RootModel>(rootModel, viewStream, contentStream);
            contentStream.Position = 0;
            var content2 = new StreamContent(contentStream);
            content2.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return content2;
        }
    }
}
