using System.Web.Http;
using HypermediaApiSiteConsole;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiContent.Root.About
{
    public class AboutController : ApiController
    {

        public View Get()
        {
        
            var template = this.LoadResource("AboutView.cshtml");

            var view = new View(template, new AboutModel());

            return view;

        }
    }
}
