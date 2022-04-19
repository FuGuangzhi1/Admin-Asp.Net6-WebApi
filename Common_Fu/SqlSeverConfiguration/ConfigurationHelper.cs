using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common_Fu
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration = null!;
        public static void AddConfig
            (this IServiceCollection service, IConfiguration configuration)
             => ConfigurationHelper.GetConfiguration = configuration;
    }
}