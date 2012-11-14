using System.Web.Http;
using HypermediaApiContent.Model;
using webapi_outputcache;

namespace HypermediaApiContent.Root.Learning
{
    public class LearningController : ApiController
    {
        private readonly InfoRepository _infoRepository;

        public LearningController(InfoRepository infoRepository) {
            _infoRepository = infoRepository;
        }

        [WebApiOutputCache(1, 1, false)]
        public LearningViewModel Get()
        {
        
            return new LearningViewModel(_infoRepository);

        }
    }
}
