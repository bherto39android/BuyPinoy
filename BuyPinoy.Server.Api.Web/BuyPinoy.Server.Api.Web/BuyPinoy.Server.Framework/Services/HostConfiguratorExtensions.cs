using Topshelf;
using Topshelf.HostConfigurators;

namespace BuyPinoy.Server.Framework.Services
{
    public static class HostConfiguratorExtensions
    {
        public static void RunAsWindowService<TStartup>(this HostConfigurator config, string module, int port, string host = "")
        {
            config.Service<IBackgroundService>(sc =>
            {
                sc.ConstructUsing(() => new BackgroundService<TStartup>(module, port,host ));
                sc.WhenStarted((service, hostControl) => service.Start(hostControl));
                sc.WhenStopped((service, hostControl) => service.Stop(hostControl));
            });

            config.SetServiceName(module);
            config.SetDisplayName("Server: " + module);
            config.SetDescription(module);
            config.EnablePauseAndContinue();
            config.EnableShutdown();
            config.RunAsNetworkService();
        }
    }
}
