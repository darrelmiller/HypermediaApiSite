using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole
{
    public static class ApiControllerExtensions
    {
        public static Stream LoadResource(this ApiController controller, string name)
        {
            return controller.GetType().Assembly.GetManifestResourceStream(controller.GetType(), name);
        }
    }
}
