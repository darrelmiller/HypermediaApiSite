using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

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

        protected override bool CanWriteType(Type type)
        {
            return true;
        }

        protected override System.Threading.Tasks.Task OnWriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext, System.Net.TransportContext transportContext)
        {
            var template = _viewEngine.GetTemplate(type, contentHeaders.ContentType);

            MethodInfo method = typeof(IViewEngine).GetMethod("RenderTo");
            MethodInfo generic = method.MakeGenericMethod(type);
            generic.Invoke(_viewEngine, new object[] { value, template, stream });    //_viewEngine.RenderTo(value, template, stream);
          
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(stream);
            return tcs.Task;
        }
    }
}
