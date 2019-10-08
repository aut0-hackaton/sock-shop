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
        private readonly By count = By.CssSelector("tr > td:nth-child(4) > input");
        private IWebElement scope;
        public CartItem(IWebElement scope)
        {
            this.scope = scope;
        }

        public string Name => scope.FindElement(name).Text;
        public string Count
        {
            get { return scope.FindElement(count).Text; }
            set { scope.FindElement(count).SendKeys(value);}
        }
    }
}
