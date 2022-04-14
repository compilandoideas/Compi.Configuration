using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.Clean.Service.Extensions
{
   public static class SerilogCustomEmailExtension
    {
        const string DefaultOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}";

        public static LoggerConfiguration CustomEmail(
            this LoggerSinkConfiguration loggerConfiguration,
            CustomEmailConnectionInfo connectionInfo,
            string outputTemplate = DefaultOutputTemplate,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
        )
        {
            return loggerConfiguration.Email(
                connectionInfo,
                outputTemplate,
                restrictedToMinimumLevel
            );
        }

        public class CustomEmailConnectionInfo : EmailConnectionInfo
        {
            public CustomEmailConnectionInfo()
            {
                NetworkCredentials = new NetworkCredential();
                ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;
            }


        }
    }
}
