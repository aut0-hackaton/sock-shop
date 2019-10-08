using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebShop.E2E.Tests.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitUntilPageLoaded(this IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(d =>(IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
        }
    }
}
