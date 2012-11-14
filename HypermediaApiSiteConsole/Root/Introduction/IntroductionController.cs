using System.Web.Http;
using HypermediaApiSiteConsole.Root.About;
using HypermediaApiSiteConsole.Root.Learning;
using HypermediaApiSiteConsole.Tools;
using webapi_outputcache;

namespace HypermediaApiSiteConsole.Root.Introduction
{
    public class IntroductionController : ApiController
    {
        private readonly InfoRepository _infoRepository;

        public IntroductionController(InfoRepository infoRepository) {
            _infoRepository = infoRepository;
        }

        [WebApiOutputCache(60, 10, false)]
        public View Get()
        {
        
            var template = this.LoadResource("IntroductionView.cshtml");

            var view = new View(template, new IntroductionModel(_infoRepository));

            return view;

        }
    }
}
