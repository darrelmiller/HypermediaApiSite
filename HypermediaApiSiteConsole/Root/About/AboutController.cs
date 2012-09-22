using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole.Root.About
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
