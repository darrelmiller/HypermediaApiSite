using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace HypermediaApiContent.img
{
    public class ImagesController : ApiController
    {

        public HttpResponseMessage Get(string name)
        {
            var stream = GetType().Assembly.GetManifestResourceStream(this.GetType(), name);
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            var response = new HttpResponseMessage() { Content = content };
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = new TimeSpan(1, 0, 0)
            };
            return response;
        }
    }
}
