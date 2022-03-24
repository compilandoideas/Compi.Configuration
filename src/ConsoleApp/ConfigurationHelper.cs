using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.ConsoleApp
{
    public static class ConfigurationHelper
    {

        public static string GetParameterFromIniFile(string variableName, string filePath)
        {
            string result = "";          

            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);
            
            using var streamFile = File.OpenText(filePath);

            while (!streamFile.EndOfStream)
            {
                string lineReaded = streamFile.ReadLine();
                if (!string.IsNullOrEmpty(lineReaded))
                {
                    string[] lineSplited = lineReaded.Split("=");
                    if (lineSplited[0].Equals(variableName, StringComparison.OrdinalIgnoreCase))                                                   
                        return lineSplited[1];                        
                }
            }
    

            return result;

        }
    }
}
