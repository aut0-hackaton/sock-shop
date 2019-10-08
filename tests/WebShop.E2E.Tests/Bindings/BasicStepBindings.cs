using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebShop.E2E.Tests.Configuration;
using WebShop.Ui.Enums;
using WebShop.Ui.Extensions;
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

        [Given(@"logged in as (.*)")]
        public void GivenILoggedInAsUser(string userName)
        {
            var loginForm = new BasePage(webDriver).LoginForm;
            var user = TestConfig.Instance.TestUsers.FirstOrDefault(u => u.Name.Equals(userName));
            loginForm.Username = user.Name;
            loginForm.Password = user.Password;
            loginForm.Login(true);
        }

        [Given(@"it is (.*) page")]
        [When(@"I navigate to (.*) page")]
        public void GivenItIsCatalogPage(string pageName)
        {
            var navbar = new BasePage(webDriver).NavBar;
            navbar.NavigateTo(pageName);
        }
    }
}
