using System;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HypermediaApiSiteConsole.ViewEngine;

namespace HypermediaApiSiteConsole.Tools
{
    public class PlainTextFormatter : MediaTypeFormatter
    {
        public PlainTextFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IPlainTextView).IsAssignableFrom(type);
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var viewmodel = value as IPlainTextView;
            var sr = new StreamWriter(writeStream);
            sr.Write(viewmodel.CreateView());
            sr.Flush();
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(writeStream);
            return tcs.Task;
        }
    }


}
