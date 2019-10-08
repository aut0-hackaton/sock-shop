using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using WebShop.Ui.Extensions;
using WebShop.Ui.PageObjects.Content.CartContent;

namespace WebShop.Ui.PageObjects
{
    public class CartPage : BasePage
    {
        private readonly By items = By.CssSelector("#cart-list > tr");
        private readonly By updateBasketBtn = By.CssSelector("a[onclick*='updateCart()']");
        private readonly By total = By.CssSelector("cartTotal");
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public List<CartItem> CartItems => webDriver.FindElements(items).Select(i => new CartItem(i)).ToList();
        public string TotalPrice => webDriver.FindElement(total).Text;
        public void UpdateBasket()
        {
            webDriver.FindElement(updateBasketBtn).Click();
            webDriver.WaitUntilPageLoaded();
        }
    }
}
