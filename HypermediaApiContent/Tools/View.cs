using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using HypermediaApiContent.Tools;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace HypermediaApiSiteConsole.Tools
{
    public class View
    {
        private readonly Stream _template;
        private readonly object _model;

        public static IViewEngine ViewEngine { get; set; }

        static View()
        {
            ViewEngine = new RazorViewEngine();
        }

        public View(Stream template, object model)
        {
            _template = template;
            _model = model;
        }


        public void WriteToStream(Stream stream)
        {

            MethodInfo method = typeof(IViewEngine).GetMethod("RenderTo");
            MethodInfo generic = method.MakeGenericMethod(_model.GetType());
            generic.Invoke(ViewEngine, new object[] { _model, _template, stream });    

        }

        public StreamContent CreateContent()
        {
            var memoryStream = new MemoryStream();
            WriteToStream(memoryStream);
            memoryStream.Position = 0;
            return new StreamContent(memoryStream);
        }
    }
}
