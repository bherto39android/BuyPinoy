
using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace BuyPinoy.Server.Framework.Middlewares.Logging
{
    public class ConsoleTraceRequest : LoggingMiddleware
    {
        public ConsoleTraceRequest(OwinMiddleware next) : base(next)
        {
        }

        protected override Task LogAsync(IOwinContext context, long millis)
        {
            Console.WriteLine("[{0}] {1} ({2}:{3} ms)",
               context.Response.StatusCode,
               context.Request.Uri.PathAndQuery,
               GetUser(context), millis);
            return Task.FromResult(0);
        }
    }
}
