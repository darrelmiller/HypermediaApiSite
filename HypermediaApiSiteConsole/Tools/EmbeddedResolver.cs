using System.IO;
using RazorEngine.Templating;

namespace HypermediaApiSiteConsole
{
    public class EmbeddedResolver : ITemplateResolver
    {
        public string Resolve(string name)
        {
            var viewStream = this.GetType().Assembly.GetManifestResourceStream(typeof(RootController), "Includes." + name);

            return new StreamReader(viewStream).ReadToEnd();
        }
    }
}