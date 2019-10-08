using OpenQA.Selenium;
using WebShop.E2E.Tests.Extensions;
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
            webDriver.WaitUntilPageLoaded();
        }

        public BasePage(IWebDriver webDriver, By scope)
        {
            this.webDriver = webDriver;
            this.scope = webDriver.FindElement(scope);
            webDriver.WaitUntilPageLoaded();
        }

        public LoginForm LoginForm
        {
            get
            {
                webDriver.FindElement(login).Click();
                webDriver.WaitUntilPageLoaded();
                return new LoginForm(webDriver);
            }
        }

        public NavBar NavBar => new NavBar(webDriver);
    }
}
