using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects
{
    public class BasePage
    {
        private IWebDriver webDriver;
        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}
