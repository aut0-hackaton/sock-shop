using System;
using Microsoft.Extensions.Configuration;

namespace WebShop.Api.Configuration
{
    public class AppSettings
    {
        private readonly IConfigurationRoot configuration;

        private AppSettings(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        public static AppSettings Instance
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appSettings.json", true, true);

                return new AppSettings(builder.Build());
            }
        }

        public Uri Endpoint => new Uri(configuration["BaseUrl"]);
    }
}
