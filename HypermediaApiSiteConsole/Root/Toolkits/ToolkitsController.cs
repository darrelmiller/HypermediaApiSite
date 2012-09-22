using System.Web.Http;
using HypermediaApiSiteConsole.Root.Introduction;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole.Root.Toolkits
{
    public class ToolkitsController : ApiController
    {

        public View Get()
        {
        
            var template = this.LoadResource("ToolkitsView.cshtml");

            var view = new View(template, new ToolkitsModel());

            return view;

        }
    }
}
