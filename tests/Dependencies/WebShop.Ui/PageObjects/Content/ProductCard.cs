using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects.Content
{
    public class ProductCard
    {
        private readonly By name = By.CssSelector("h3 > a");
        private readonly By price = By.ClassName("price");
        private readonly By addToCartBtn = By.ClassName("btn-primary");

        private IWebElement scope;
        public ProductCard(IWebElement scope)
        {
            this.scope = scope;
        }

        public string Name => scope.FindElement(name).Text;

        public string Price => scope.FindElement(price).Text;

        public void AddToCart()
        {
            scope.FindElement(addToCartBtn).Click();
        }
    }
}
