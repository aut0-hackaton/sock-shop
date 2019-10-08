using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebShop.E2E.Tests.Configuration;

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
            webDriver.Navigate().GoToUrl("http://ec2-54-224-182-6.compute-1.amazonaws.com/index.html");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver(TestConfig.Instance.BaseDirectory);
        }
    }
}
