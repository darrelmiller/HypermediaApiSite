using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace HypermediaApiOwinHost
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0 && args[args.Length - 1].Contains("/console"))
            {

                var baseAddress = (args.Length == 0) ? "http://hypermediaapi.com" : args[0];

                using (WebApplication.Start<Startup>(baseAddress))
                {
                    Console.WriteLine("Server running on {0}", baseAddress);
                    Console.ReadLine();
                }
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new HypermediaApiService() });
            }
          

            

        }

      
    }
}
