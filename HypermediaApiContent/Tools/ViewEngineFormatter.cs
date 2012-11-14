using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using HypermediaApiSiteConsole.ViewEngine;
using System.Linq;

namespace HypermediaApiSiteConsole.Tools
{


    public class ViewEngineFormatter : MediaTypeFormatter
    {
        private readonly IViewEngine _viewEngine;

        public ViewEngineFormatter(IViewEngine viewEngine)
        {
            _viewEngine = viewEngine;

            foreach (var mediaTypeHeaderValue in _viewEngine.SupportedMediaTypes)
            {
                SupportedMediaTypes.Add(mediaTypeHeaderValue);    
            }
        }

        public override bool CanReadType(Type type)
        {
            
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            
            return typeof(View) == type || type.GetInterfaces().Contains(typeof(IViewEngineView));
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var viewmodel = value as IViewEngineView;
            View view;
            if (viewmodel != null)
            {
                view = viewmodel.CreateView();
            }
            else
            {
                view = (View) value;
            }

            view.WriteToStream(writeStream);
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(writeStream);
            return tcs.Task;
        }

       

        

    }
}
