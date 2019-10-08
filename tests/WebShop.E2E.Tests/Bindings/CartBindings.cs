using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebShop.E2E.Tests.Configuration;
using WebShop.Ui.Enums;
using WebShop.Ui.Extensions;
using WebShop.Ui.PageObjects;

namespace WebShop.E2E.Tests.Bindings
{
    [Binding]
    public sealed class CartBindings
    {
        private IWebDriver webDriver;
        private readonly ScenarioContext context;

        public CartBindings(ScenarioContext injectedContext)
        {
            context = injectedContext;
            webDriver = context.Get<IWebDriver>();
        }

        [Given(@"product ""(.*)"" is added to cart")]
        public void GivenIAddProductInCart(string productName)
        {
            var catalogPage = new CatalogPage(webDriver);

            var desiredProduct = catalogPage.ProductCards.FirstOrDefault(p => p.Name.Equals(productName));
            if (desiredProduct == null)
            {
                throw new Exception($"Product {productName} was not found");
            }
            desiredProduct.AddToCart();
            webDriver.WaitUntilPageLoaded();
        }

        [Then(@"there is new item named ""(.*)"" in cart")]
        public void ThenThereIsNewItemNamedInCart(string itemName)
        {
            var cartPage = new CartPage(webDriver);

            Assert.IsTrue(cartPage.CartItems.Exists(i => i.Name.Equals(itemName)),
                $"Item '{itemName}' was not added");
        }

        [When(@"I change quantity of socks ""(.*)"" to (.*)")]
        public void WhenIChangeQuantityOfSocksTo(string itemName, string count)
        {
            var cartPage = new CartPage(webDriver);
            var item = cartPage.CartItems
                .FirstOrDefault(i => i.Name.Equals(itemName));
            if (item ==null)
            {
                throw new Exception("Cannot find");
            }
            item.Count = count;
        }

        [When(@"I press button ""(.*)""")]
        public void WhenIPressButton(string p0)
        {
            var cartPage = new CartPage(webDriver);
            cartPage.UpdateBasket();
        }

        [Then(@"total price is (.*)")]
        public void ThenTotalPriceIs(string expectedPrice)
        {
            var cartPage = new CartPage(webDriver);
            Assert.AreEqual(expectedPrice, cartPage.TotalPrice);
        }

    }
}
