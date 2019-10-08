using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using WebShop.Ui.PageObjects.Content.CartContent;

namespace WebShop.Ui.PageObjects
{
    public class CartPage : BasePage
    {
        private readonly By items = By.CssSelector("#cart-list > tr");
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public List<CartItem> CartItems => webDriver.FindElements(items).Select(i => new CartItem(i)).ToList();
    }
}
