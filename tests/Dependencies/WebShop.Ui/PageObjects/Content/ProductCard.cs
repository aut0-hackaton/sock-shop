using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects.Content
{
    public class ProductCard
    {
        private IWebElement scope;
        public ProductCard(IWebElement scope)
        {
            this.scope = scope;
        }
    }
}
