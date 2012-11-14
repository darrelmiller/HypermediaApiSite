using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using HypermediaApiContent;

namespace HypermediaApiSiteConsole
{
    public class HypermediaApiConsole {
        public void Run(string baseAddress)
        {


            var config = new HttpSelfHostConfiguration(baseAddress);
            HypermediaApiConfiguration.ConfigureSite(config);

            var host = new HttpSelfHostServer(config);
           
            host.OpenAsync().Wait();

            Console.WriteLine("Press enter to shutdown service");
            Console.ReadLine();

            host.CloseAsync().Wait();
        }
    }
}
