using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;
using System.Web.Http;
using HypermediaApiContent;
using Microsoft.Owin.Hosting;

namespace HypermediaApiOwinHost
{
    partial class HypermediaApiService : ServiceBase
    {

        private IDisposable _WebApp;
        
        public HypermediaApiService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try {

                var baseAddress = (args.Length == 0) ? "http://hypermediaapi.com" : args[0];

                Trace.WriteLine(String.Format("Service starting on address:  {0}", baseAddress));

                var config = new HttpConfiguration();
                HypermediaApiConfiguration.ConfigureSite(config);

                Trace.WriteLine("Config completed");

                _WebApp = WebApplication.Start<Startup>(baseAddress);

                Trace.WriteLine("Service started");

            } catch(Exception ex)
            {
                Trace.TraceError((ex.InnerException != null ? ex.InnerException.Message : ex.Message));
                if (_WebApp != null) _WebApp.Dispose();
            }

        }

        protected override void OnStop()
        {
            try
            {
                Trace.WriteLine("Service stopping");

               _WebApp.Dispose();
            } catch(Exception ex)
            {
                Trace.TraceError((ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }
    }

    [RunInstaller(true)]
    public partial class SiteInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller _ProcessInstaller;
        private ServiceInstaller _Installer;

        public SiteInstaller()
        {
           
            _ProcessInstaller = new ServiceProcessInstaller();
            _Installer = new ServiceInstaller();

            _ProcessInstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            _ProcessInstaller.Password = null;
            _ProcessInstaller.Username = null;

            _Installer.ServiceName = "HypermediaAPI";

            Installers.AddRange(
                new Installer[] { _ProcessInstaller, _Installer });

        }
    }
}
