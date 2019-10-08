using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using WebShop.Ui.PageObjects.Content;

namespace WebShop.Ui.PageObjects
{
    public class CatalogPage : BasePage
    {
        private readonly By products = By.CssSelector("div[id='products'] > div");

        public CatalogPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public List<ProductCard> ProductCards =>
            webDriver.FindElements(products).Select(p => new ProductCard(p)).ToList();
    }
}
