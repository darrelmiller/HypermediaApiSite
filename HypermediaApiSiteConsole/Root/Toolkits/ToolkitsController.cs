using System.Web.Http;
using HypermediaApiSiteConsole.Root.Introduction;
using Parrot.Nodes;
using Parrot.Infrastructure;
using Parrot.Parser;
using Parrot.Renderers;
using System.Net.Http;
using System.IO;
using DependencyResolver = Parrot.Infrastructure.DependencyResolver;
using Parrot.Renderers.Infrastructure;
using System.Net.Http.Headers;
using System.Text;


namespace HypermediaApiSiteConsole.Root.Toolkits
{
    public class ToolkitsController : ApiController
    {

        public HttpResponseMessage Get()
        {
            var model = new
            {
                Header = "Parrot",
                Description = "Something something about Parrot",
                Features = new[] {
    "Familiar syntax",
    "Extensible output",
    "Simple model binding"
  }
            };

            var stream = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), "ParrotTemplate.txt");

            var host = new MyHost();

            var parrotDoc = new Document(host);
            var parser = new Parser(host);
            parser.Parse(stream, out parrotDoc);

            var renderer = new HtmlRenderer(host);
            var content = renderer.Render(parrotDoc,model);

            return new HttpResponseMessage()
            {
                Content = new StringContent(content,Encoding.UTF8,"text/html")
            };

            //var template = this.LoadResource("ToolkitsView.cshtml");

            //var view = new View(template, new ToolkitsModel());

            //var parrotView = new View(
            //return view;

        }
    }

    public class MyHost : Host {
        public MyHost()
            : base(new DependencyResolver())
        {
            InitializeRendererFactory();
         //   DependencyResolver.Register(typeof(IPathResolver), () => new PathResolver());
            DependencyResolver.Register(typeof(DocumentRenderer), () => new DocumentRenderer(this));
            DependencyResolver.Register(typeof(IModelValueProviderFactory), () => new ModelValueProviderFactory());
        }

        private void InitializeRendererFactory()
        {
            var factory = new RendererFactory(this);

           // factory.RegisterFactory("layout", new LayoutRenderer(this));
            //factory.RegisterFactory("content", new ContentRenderer(this));

            DependencyResolver.Register(typeof(IRendererFactory), () => factory);
        }
}

   
}
