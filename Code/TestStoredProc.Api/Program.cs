using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestStoredProc.Api.Bootstrapper.Interfaces;


namespace TestStoredProc.Api
{
    public class Program
    {

        static IList<IHostBootstrapper> _serviceList;
        public static void Main(string[] args)
        {
            try{
                IdentifyServices();
                BootstrapServices(args).Build().Run();
            } finally {
                CleanUp();
            }
        }

        public static void IdentifyServices()
        {
            _serviceList = new List<IHostBootstrapper>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IHostBootstrapper)) && type.IsClass == true)
                {
                    IHostBootstrapper hostInstance = (IHostBootstrapper)Activator.CreateInstance(type);
                    _serviceList.Add(hostInstance);
                }
            }
        }

        public static IHostBuilder BootstrapServices(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>().ConfigureKestrel(options =>
                     {
                         options.AllowSynchronousIO = true;
                     });
                 });

            foreach (var bootStrapper in _serviceList)
            {
                bootStrapper.BuildHost(hostBuilder);
            }


            return hostBuilder;
        }

        public static void CleanUp()
        {
            foreach (var cleaner in _serviceList)
            {
                cleaner.CleanUp();
            }
        }
    }
}
