using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WebShop.E2E.Tests.Configuration
{
    public class TestConfig
    {
        private readonly IConfiguration config;
        private TestConfig()
        {
            var assemblyUri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            ExecutingAssemblyPath = Path.GetDirectoryName(Uri.UnescapeDataString(assemblyUri.Path));

            config = new ConfigurationBuilder()
                .SetBasePath(ExecutingAssemblyPath)
                .AddJsonFile("specflow.json", false, true)
                .Build();
        }
        public static TestConfig Instance => new TestConfig();
        /// <summary>
        /// Executed assembly root directory
        /// </summary>
        public string ExecutingAssemblyPath { get; }
            //.Split("SpecFlowPlusRunner")[0]
        public Uri BaseUrl => new Uri(config["AppSettings:BaseUrl"]);
    }
}
