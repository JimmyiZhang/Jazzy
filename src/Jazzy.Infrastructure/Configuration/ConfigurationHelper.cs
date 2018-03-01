using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Jazzy.Infrastructure.Configuration
{
    public static class ConfigurationHelper
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigurationHelper()
        {
            // ReloadOnChange = true 当 appsettings.json 被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

        public static string GetSettings(string key)
        {
            return Configuration[key];
        }

        public static string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }
    }
}
