using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebShop.E2E.Tests.Configuration
{
    public class UserConfig
    {
        private readonly IConfigurationSection configurationSection;

        public UserConfig(IConfigurationSection configurationSection)
        {
            this.configurationSection = configurationSection;
        }

        public string Name => configurationSection["Username"];
        
        public string Password => configurationSection["Password"];
    }
}
