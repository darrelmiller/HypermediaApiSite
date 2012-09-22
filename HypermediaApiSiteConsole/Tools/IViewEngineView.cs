using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HypermediaApiSiteConsole.Tools;

namespace HypermediaApiSiteConsole.ViewEngine
{
    interface IViewEngineView
    {
        View CreateView();
    }
}
