using System.IO;
using RazorEngine.Templating;

namespace HypermediaApiSiteConsole
{
    public class EmbeddedResolver : ITemplateResolver
    {
        public string Resolve(string name)
        {

            name = name.Replace("~/", "").Replace("/", ".");  //Convert "web path" to "resource path"
            var viewStream = this.GetType().Assembly.GetManifestResourceStream(typeof(RootController), name);

            return new StreamReader(viewStream).ReadToEnd();
        }
    }
}