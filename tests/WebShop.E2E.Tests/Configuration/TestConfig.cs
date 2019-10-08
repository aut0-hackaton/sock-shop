using System;

namespace WebShop.E2E.Tests.Configuration
{
    public class TestConfig
    {
        public static TestConfig Instance => new TestConfig();

        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory.Split("SpecFlowPlusRunner")[0];
    }
}
