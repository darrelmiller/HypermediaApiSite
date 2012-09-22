using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using webapi_outputcache;

namespace HypermediaApiSiteConsole.js
{
    public class JavascriptController : ApiController
    {
         [WebApiOutputCache(10, 3600, false)]
        public HttpResponseMessage Get(string name)
        {
            var stream = GetType().Assembly.GetManifestResourceStream(this.GetType(), name);
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("text/javascript");
            var response = new HttpResponseMessage() { Content = content };
            response.Headers.CacheControl = new CacheControlHeaderValue()
                                                {
                                                    MaxAge = new TimeSpan(1,0,0)
                                                };
            return response;
        }
    }
}
