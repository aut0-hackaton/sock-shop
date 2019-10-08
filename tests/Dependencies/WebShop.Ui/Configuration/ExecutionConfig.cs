using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WebShop.Ui.Configuration
{
    [Binding]
    public sealed class ExecutionConfig
    {
        private IWebDriver webDriver;
        private ScenarioContext scenarioContext;

        public ExecutionConfig(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            webDriver = CreateChromeDriver();
            scenarioContext.Set(webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        private IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver($"{AppDomain.CurrentDomain.BaseDirectory}/chromedriver.exe");
        }
    }
}
