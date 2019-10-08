using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects
{
    class CatalogPage : BasePage
    {
        private readonly By products = By.CssSelector("div[id='products'] > div")

        public CatalogPage(IWebDriver webDriver) : base(webDriver)
        {
        }
    }
}
