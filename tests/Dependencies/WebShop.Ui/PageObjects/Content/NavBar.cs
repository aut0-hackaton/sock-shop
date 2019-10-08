using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using WebShop.Ui.Enums;

namespace WebShop.Ui.PageObjects.Content
{
    public class NavBar : BasePage
    {
        private readonly By homeBtn = By.Id("tabIndex");
        private readonly By catalogueBtn = By.Id("tabCatalogue");
        private readonly By cartBtn = By.CssSelector("div[id='basket-overview']>a");
        public NavBar(IWebDriver webDriver) : base(webDriver, By.Id("navbar"))
        {
        }

        public void NavigateTo(Pages page)
        {
            pageObjectByPage[page].Invoke();
        }

        private void GoToHome()
        {
            scope.FindElement(homeBtn).Click();
        }

        private void GoToCatalogue()
        {
            scope.FindElement(catalogueBtn).Click();
        }
        private void GoToCart()
        {
            scope.FindElement(cartBtn).Click();
        }
        private Dictionary<Pages, Action> pageObjectByPage => new Dictionary<Pages, Action>
        {
            {Pages.Home, GoToHome},
            {Pages.Catalog, GoToCatalogue},
            {Pages.Cart, GoToCart},
        };
    }
}
