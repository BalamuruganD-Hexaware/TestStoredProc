using TestStoredProc.Api.Installer;
using TestStoredProc.Api.Middleware;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TestStoredProc.Api.OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using System.Reflection;
using TestStoredProc.Api.Bootstrapper.Interfaces;
using System.Linq;

namespace TestStoredProc.Api
{
    public class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        WebHostEnvironment = webHostEnvironment;
    }

    public IConfiguration Configuration { get; }
    public IHostEnvironment WebHostEnvironment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }
        services.AddCors(options =>
            {
                options.AddDefaultPolicy(options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

        InstallServices(services);

        APIInstaller apiInstaller = new APIInstaller(services, Configuration);
        apiInstaller.Install();
    }

    public void InstallServices(IServiceCollection services)
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (type.GetInterfaces().Contains(typeof(IServiceBootstrapper)) && type.IsClass == true)
            {
                IServiceBootstrapper serviceInstance = (IServiceBootstrapper)Activator.CreateInstance(type);
                serviceInstance.BuildService(services, Configuration);
            }
        }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(
            c => c.SerializeAsV2 = true
        );
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestStoredProc V1");
        });

        app.UseHttpsRedirection();

        app.UseCors();

        app.UseRouting();

        app.UseElmah();

        app.UseRequestLoggingMiddleWare();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
