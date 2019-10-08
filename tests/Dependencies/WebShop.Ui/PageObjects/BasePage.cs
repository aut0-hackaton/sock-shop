using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using WebShop.Ui.PageObjects.Content;

namespace WebShop.Ui.PageObjects
{
    public class BasePage
    {
        private readonly By login = By.Id("login");

        protected IWebDriver webDriver;
        protected IWebElement scope;
        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public BasePage(IWebDriver webDriver, By scope)
        {
            this.webDriver = webDriver;
            this.scope = webDriver.FindElement(scope);
        }

        public LoginForm OpenLoginForm()
        {
            webDriver.FindElement(login).Click();
            return new LoginForm(webDriver);
        }
    }
}
