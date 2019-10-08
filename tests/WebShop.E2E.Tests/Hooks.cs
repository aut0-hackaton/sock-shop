using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WebShop.E2E.Tests
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IWebDriver webDriver;
        private ScenarioContext scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            webDriver = CreateWebDriver();
            webDriver.Manage().Window.Maximize();
            scenarioContext.Set(webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver($"{AppDomain.CurrentDomain.BaseDirectory}/chromedriver.exe");
        }
    }
}
