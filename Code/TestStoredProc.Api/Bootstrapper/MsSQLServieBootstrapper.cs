using TestStoredProc.Api.Bootstrapper.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestStoredProc.Data.Repositories;


namespace TestStoredProc.Api.ServiceBootstrapper
{
    public class MsSQLServieBootstrapper : IServiceBootstrapper
    {
        public void BuildService(IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContextPool<DataContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("SqlDBConnectionString")));
        }

        
    }
}
