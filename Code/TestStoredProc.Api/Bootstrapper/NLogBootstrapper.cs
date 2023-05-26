using TestStoredProc.Api.Bootstrapper.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;


namespace TestStoredProc.Api.DependencyInstaller
{
    public class NLogBootstrapper : IHostBootstrapper
    {
        public void BuildHost(IHostBuilder host)
        {
            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            }).UseNLog();
        }

        public void CleanUp()
        {
            NLog.LogManager.Shutdown();
        }
    }
}
