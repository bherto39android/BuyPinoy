using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuyPinoy.Server.Framework.Services;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace BuyPinoy.Server.Api.Web.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Start OWIN host 
           /* using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

               /* var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result); #1#
            }*/

            try
            {
                HostFactory.Run(config => config.RunAsWindowService<Startup>("PinoyServer", 11233,"localhost" ));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
