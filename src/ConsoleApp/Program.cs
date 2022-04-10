using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Compi.Configuration.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationClassicWay();

            ConfigurationWithConfigurationApi(args);


        }

        private static void ConfigurationWithConfigurationApi(string[] args)
        {

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationBuilder configurationBuilder =
                new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json",
                             optional: false,
                             reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json",
                             optional: true,
                             reloadOnChange: true)
                .AddCommandLine(args);



            IConfigurationRoot configuration = configurationBuilder.Build();


            // Task.Delay(5000).Wait();

            var var1 = configuration["Var1"];

            var var2 = configuration.GetSection("vAr1").Value;

            var var3 = configuration.GetRequiredSection("vaR1").Value.ToString();



            // var settings = configuration.GetSection(nameof(Settings)).Get<Settings>();



            Settings settings = new()
            {
                Var1 = "default value"
            };


            configuration.GetSection(nameof(Settings)).Bind(settings);



            Console.WriteLine($"var1: {var1}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;



            // Console.ReadLine();
            // configurationBuilder.Sources.Clear();
            // configurationBuilder
            //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            //.AddEnvironmentVariables(prefix: "Algo_")
            //.AddCommandLine(args)
            //.Build();
        }


        private static void ConfigurationClassicWay()
        {
            const string configFileName = "configuration.ini";

            var sender = ConfigurationHelper.GetParameterFromIniFile("sender", configFileName);
            var password = ConfigurationHelper.GetParameterFromIniFile("password", configFileName);
            var smtp = ConfigurationHelper.GetParameterFromIniFile("smtp", configFileName);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Sender: {sender}");
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"SMTP: {smtp}");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
