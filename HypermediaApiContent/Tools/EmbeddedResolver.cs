using System.IO;
using RazorEngine.Templating;

namespace HypermediaApiContent.Tools
{
    public class EmbeddedResolver : ITemplateResolver
    {
        public string Resolve(string name)
        {

            name = name.Replace("~/", "").Replace("/", ".");  //Convert "web path" to "resource path"
            var viewStream = this.GetType().Assembly.GetManifestResourceStream("HypermediaApiContent."+name);

            return new StreamReader(viewStream).ReadToEnd();
        }
    }
}