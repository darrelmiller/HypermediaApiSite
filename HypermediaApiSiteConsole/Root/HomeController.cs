using System.Web.Http;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole.Root
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
