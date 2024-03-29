﻿using System;
using System.Threading;
using OpenQA.Selenium;

namespace WebShop.Ui.PageObjects.Content
{
    public class LoginForm : BasePage
    {
        private readonly By userName = By.Id("username-modal");
        private readonly By password = By.Id("password-modal");
        private readonly By loginBtn = By.CssSelector("button.btn-primary");

        public LoginForm(IWebDriver webDriver) 
            : base(webDriver, By.ClassName("modal-dialog"))
        {
        }

        public string Username
        {
            get => scope.FindElement(userName).Text;
            set => scope.FindElement(userName).SendKeys(value);
        }

        public string Password
        {
            get => scope.FindElement(password).Text;
            set => scope.FindElement(password).SendKeys(value);
        }

        public BasePage Login(bool expectedSuccess)
        {
            scope.FindElement(loginBtn).Click();
            if (expectedSuccess)
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            return this;
        }
    }
}
