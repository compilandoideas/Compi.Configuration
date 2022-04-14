using Compi.Configuration.Clean.Service.Extensions;
using Compi.Configuration.Clean.Service.HostedServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Compi.Configuration.Clean.Service
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            try
            {
                Log.Information("Getting the motors running...");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
            .UseSerilog((context, services, loggerConfiguration) =>
            {

                //Serilog.Debugging.SelfLog.Enable(Console.Error);

                loggerConfiguration
                .ReadFrom.Configuration(context.Configuration);
            })
            .UseWindowsService();
    }
}
