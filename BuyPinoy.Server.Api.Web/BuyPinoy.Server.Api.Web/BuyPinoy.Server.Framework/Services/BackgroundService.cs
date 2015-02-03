using System;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace BuyPinoy.Server.Framework.Services
{
    public class BackgroundService<TStartup> : IBackgroundService
    {
        private IDisposable _webAppHolder;

        public BackgroundService(string module, int port, string host)
        {
            Module = module;
            Port = port;
            Host = host;
        }

        public bool Start(HostControl hostControl)
        {
            if (_webAppHolder == null)
            {
                string url = string.Format("http://{0}:{1}/", Host, Port);

                Console.WriteLine("Starting " + Module);
                Console.WriteLine("Port: " + Port);
                
                var startOptions = new StartOptions { Port = Port };

                var localhostUrl = string.Format("http://localhost:{0}/", Port);
                startOptions.Urls.Add(localhostUrl);
                Console.WriteLine("Url:{0}", localhostUrl);

                if (!string.IsNullOrEmpty(Host))
                {
                    startOptions.Urls.Add(url);
                    Console.WriteLine("Url:{0}", url);
                }
                try
                {
                    _webAppHolder = WebApp.Start<TStartup>(startOptions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            if (_webAppHolder != null)
            {
                Console.WriteLine("Exiting...");
                _webAppHolder.Dispose();
            }

            return true;
        }

        public string Module { get; private set; }
        public int Port { get; private set; }
        public string Host { get; private set; }
    }
}
