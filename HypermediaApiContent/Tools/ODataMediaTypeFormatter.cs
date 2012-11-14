using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HypermediaApiContent.Tools;

namespace HypermediaApiSiteConsole.Tools
{
    public class ODataMediaTypeFormatter : MediaTypeFormatter
    {
        public ODataMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("application/atom+xml"));
            this.AddUriPathExtensionMapping("atom", new MediaTypeHeaderValue("application/atom+xml"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IODataView).IsAssignableFrom(type);
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var viewmodel = value as IODataView;
            var resp= viewmodel.CreateView();
            resp.GetStream().CopyTo(writeStream);
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(writeStream);
            return tcs.Task;
        }
    }
}
