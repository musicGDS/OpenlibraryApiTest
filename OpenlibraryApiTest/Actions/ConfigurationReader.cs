using Microsoft.Extensions.Configuration;
using System.IO;

namespace OpenlibraryApiTest.Handlers
{
    public static class ConfigurationReader
    {
        public static IConfiguration Configuration;
        static ConfigurationReader()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("specflow.json"))
                .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
        }
        public static string GetValue(string key)
        {
            string result = Configuration.GetSection("config").GetSection(key).Value;
            return result;
        }

    }
}
