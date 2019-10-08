using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebShop.E2E.Tests.Configuration;
using WebShop.E2E.Tests.Extensions;

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
            webDriver.Navigate().GoToUrl(TestConfig.Instance.BaseUrl);
            webDriver.WaitUntilPageLoaded();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        private IWebDriver CreateWebDriver()
        {
            return new ChromeDriver(TestConfig.Instance.ExecutingAssemblyPath);
        }

        private void SetWebDriverTimeouts()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        }
    }
}
