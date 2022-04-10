using Compi.Configuration.Clean.Service.Extensions;
using Compi.Configuration.Clean.Service.HostedServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Compi.Configuration.Clean.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configurationBuilder) =>
            {

                hostContext.HostingEnvironment.ApplicationName = "Service Example";

                configurationBuilder.Sources.Clear();

                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                configurationBuilder
                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables(prefix: "Config_")
                .AddCommandLine(args)
                .Build();


            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();

                // var emailSettings = hostContext.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
                //var connectionString = hostContext.Configuration["ConnectionStrings:ConnectionString"];


                services.AddMediator();

            })
            .UseWindowsService();
    }
}
