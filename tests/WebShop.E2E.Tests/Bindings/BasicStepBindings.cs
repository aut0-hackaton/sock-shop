using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebShop.Ui.PageObjects;

namespace WebShop.E2E.Tests.Bindings
{
    [Binding]
    public sealed class BasicStepBindings
    {
        private IWebDriver webDriver;
        private readonly ScenarioContext context;

        public BasicStepBindings(ScenarioContext injectedContext)
        {
            context = injectedContext;
            webDriver = context.Get<IWebDriver>();
        }

        [Given(@"I logged in as user(.*)")]
        public void GivenILoggedInAsUser(int p0)
        {
            var loginForm = new BasePage(webDriver).LoginForm;

            loginForm.Username = "User";
            loginForm.Password = "password";
            loginForm.Login();
        }

    }
}
