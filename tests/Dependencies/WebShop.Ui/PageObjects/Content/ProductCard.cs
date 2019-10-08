using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects.Content
{
    public class ProductCard
    {
        private readonly By price = By.ClassName("price");
        private readonly By addToCartBtn = By.ClassName("button-primary");
        private IWebElement scope;
        public ProductCard(IWebElement scope)
        {
            this.scope = scope;
        }

        public string Price => scope.FindElement(price).Text;

        public void AddToCart()
        {
            scope.FindElement(addToCartBtn).Click();
        }
    }
}
