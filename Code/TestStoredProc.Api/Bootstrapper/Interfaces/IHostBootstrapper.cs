using Microsoft.Extensions.Hosting;

namespace TestStoredProc.Api.Bootstrapper.Interfaces
{
    public interface IHostBootstrapper
    {
        void BuildHost(IHostBuilder host);
        void CleanUp() { }
    }
}
