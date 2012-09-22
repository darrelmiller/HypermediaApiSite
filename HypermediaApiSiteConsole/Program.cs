using System;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Services;
using HypermediaApiSiteConsole.Tools;
using HypermediaApiSiteConsole.ViewEngine;
using Microsoft.Practices.Unity;

namespace HypermediaApiSiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            

            if (args.Length > 0 && args[args.Length -1].Contains("/console")) {

                var console = new HypermediaApiConsole();
                var baseAddress = (args.Length == 0) ? "http://hypermediaapi.com" : args[0];
                console.Run(baseAddress);
                
            } 
            else
            {
                ServiceBase.Run(new ServiceBase[] { new HypermediaApiService() });
            }
          

        }

       
    }
}
