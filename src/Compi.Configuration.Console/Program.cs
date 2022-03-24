using System;

namespace Compi.Configuration.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
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
