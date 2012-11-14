using System.Web.Http;
using HypermediaApiSiteConsole;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiContent.Root
{
    public class HomeController : ApiController
    {

        public View Get()
        {
            var templateStream = this.LoadResource("HomeView.cshtml");
            
            var siteInfo = new HomeModel() {Site = "Hypermedia API"};

            return new View(templateStream,siteInfo);

        }

    }
}
