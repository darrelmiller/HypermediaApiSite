using System.Web.Http;
using HypermediaApiSiteConsole.Root.Introduction;
using HypermediaApiSiteConsole.Tools;
using webapi_outputcache;

namespace HypermediaApiSiteConsole.Root.Learning
{
    public class LearningController : ApiController
    {

        [WebApiOutputCache(120, 60, false)]
        public LearningViewModel Get()
        {
        
            return new LearningViewModel();

        }
    }
}
