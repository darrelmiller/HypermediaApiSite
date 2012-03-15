using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HypermediaApiSiteConsole.Tools
{
    public class HtmlContent<Model> : HttpContent
    {
        private readonly IViewEngine _viewEngine;
        private readonly Stream _template;
        private readonly Model _model;
        private readonly Stream _ContentStream = new MemoryStream();
        public HtmlContent(IViewEngine viewEngine, Stream template, Model model)
        {
            _viewEngine = viewEngine;
            _template = template;
            _model = model;
            Headers.ContentType = new MediaTypeHeaderValue("text/html");
            
            
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            _viewEngine.RenderTo<Model>(_model, _template, stream);
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(_ContentStream);
            return tcs.Task;

        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}