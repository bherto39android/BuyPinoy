using BuyPinoy.Server.Framework.Middlewares.Logging;
using Owin;

namespace BuyPinoy.Server.Framework.Middlewares
{
    public static class OwinExtensions
    {
        public static IAppBuilder UseConsoleTraceRequest(this IAppBuilder app)
        {
            return app.Use(typeof(ConsoleTraceRequest));
        }
    } 
}
