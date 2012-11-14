using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http.Headers;
using HypermediaApiSiteConsole;
using HypermediaApiSiteConsole.Tools;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace HypermediaApiContent.Tools
{
    public class RazorViewEngine  : IViewEngine
    {
        public RazorViewEngine()
        {
            var config = new TemplateServiceConfiguration();
            config.Resolver = new EmbeddedResolver();
           
            var templateService = new TemplateService(config);

            Razor.SetTemplateService(templateService);
            
        }

        public void RenderTo<T>(T model, Stream templateStream, Stream outputStream)
        {
            string template = new StreamReader(templateStream).ReadToEnd();
            string result = Razor.Parse(template, model);
            var sw = new StreamWriter(outputStream);
         
            sw.Write(result);
            sw.Flush();
        }


        public Collection<MediaTypeHeaderValue> SupportedMediaTypes
        {
            get { return new Collection<MediaTypeHeaderValue>() {new MediaTypeHeaderValue("text/html")}; }
        }

    }
}