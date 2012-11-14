using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HypermediaApiSiteConsole.Root.Learning;

namespace HypermediaApiSiteConsole.Tools
{
    public interface IODataView {
        ODataResponse CreateView();
    }
}
