using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Api.Client;
using WebShop.Api.Configuration;
using WebShop.Api.Models.Payment;

namespace WebShop.Api.Tests.Payment
{
    [TestClass]
    public class PaymentTests
    {
        private readonly IWebShopClient webShopClient;

        public PaymentTests()
        {
            //arrange
            webShopClient = new WebShopApiClient
            (
                AppSettings.Instance.Endpoint,
                "user",
                "password"
            );
        }

        [TestMethod]
        public void Possible_To_Check_Health()
        {
            var response = webShopClient.GetHealth().Result;
            Assert.IsInstanceOfType(response, typeof(GetHealthResponse));
        }
    }
}
