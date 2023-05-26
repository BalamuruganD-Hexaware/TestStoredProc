using Microsoft.Extensions.DependencyInjection;

namespace TestStoredProc.Data.Installer
{
    public class DataInstaller
    {
        private readonly IServiceCollection _service;
        public DataInstaller(IServiceCollection service)
        {
            _service = service;
        }

        public void Install()
        {
             _service.Scan(scan => scan
                                    .FromAssemblyOf<DataInstaller>()
                                    .AddClasses()
                                    .AsImplementedInterfaces()
                                    .WithScopedLifetime());
        }
    }
}
