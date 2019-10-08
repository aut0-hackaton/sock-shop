using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects.Content.CartContent
{
    public class CartItem
    {
        private readonly By name = By.CssSelector("tr > td:nth-child(3)");
        private IWebElement scope;
        public CartItem(IWebElement scope)
        {
            this.scope = scope;
        }

        public string Name => scope.FindElement(name).Text;
    }
}
