using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HypermediaApiSiteConsole.Tools
{
    public class W3CLogger : DelegatingHandler {
        private readonly string _LogFormat;
        private Stream _LogFile;
        
        public W3CLogger(string logfile) {
            _LogFormat = "{0:yyyy-MM-dd} {1:HH:mm:ss.fff} {2} {3} {4} {5} {6} {7}";
            _LogFile = FileStream.Synchronized(new FileStream(logfile,FileMode.Append,FileAccess.Write,FileShare.Write));
                }
        protected override void Dispose(bool disposing)
        {
            _LogFile.Close();

            base.Dispose(disposing);
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            request.Properties.Add(new KeyValuePair<string, object>("Stopwatch",stopwatch));

            return base.SendAsync(request, cancellationToken).ContinueWith(t => {
                                                                                Log(t.Result);
                                                                               return t.Result;
                                                                           });
        }
        private void Log(HttpResponseMessage response) {
            var request = response.RequestMessage;
            var stopwatch = (Stopwatch)request.Properties["Stopwatch"];
            stopwatch.Stop();
            var bytes = response.Content != null ? response.Content.Headers.ContentLength : 0;
            var w3clogEntry = string.Format(_LogFormat,
                                                        DateTime.Today, DateTime.Now,
                                                        GetClientIp(request),
                                                        request.Method,
                                                        request.RequestUri.AbsolutePath,
                                                        (int)response.StatusCode,
                                                        stopwatch.ElapsedMilliseconds,
                                                        bytes == null ? "-" : bytes.ToString()
                                         );
            var textWriter = new StreamWriter(_LogFile);

            textWriter.WriteLine(w3clogEntry);
            textWriter.Flush();
        }

        private string GetClientIp(HttpRequestMessage request)
        {
           if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else
            {
                return null;
            }
        }
    }

}
