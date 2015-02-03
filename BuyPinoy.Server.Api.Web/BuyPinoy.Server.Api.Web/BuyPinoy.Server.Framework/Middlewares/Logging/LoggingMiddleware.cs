using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace BuyPinoy.Server.Framework.Middlewares.Logging
{
    public abstract class LoggingMiddleware: OwinMiddleware
    {
        protected LoggingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var start = DateTime.Now;

            await Next.Invoke(context);

            var millis = (DateTime.Now - start).TotalMilliseconds;

            await LogAsync(context, (long)millis);
        }

        protected abstract Task LogAsync(IOwinContext context, long millis);

        protected static string GetUser(IOwinContext context)
        {
            return context.Request.User != null ? context.Request.User.Identity.Name : "public";
        }
    }
}
