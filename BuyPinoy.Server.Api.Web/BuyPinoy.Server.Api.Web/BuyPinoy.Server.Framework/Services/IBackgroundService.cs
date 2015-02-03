using Topshelf;

namespace BuyPinoy.Server.Framework.Services
{
    public interface IBackgroundService:ServiceControl
    {
        string Module { get; }
        int Port { get; }
        string Host { get; }
    }
}