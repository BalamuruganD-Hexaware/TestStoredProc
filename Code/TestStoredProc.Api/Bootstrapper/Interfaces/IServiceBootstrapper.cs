using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TestStoredProc.Api.Bootstrapper.Interfaces
{
    public interface IServiceBootstrapper
    {
        void BuildService(IServiceCollection services, IConfiguration configuration);
    }
}
