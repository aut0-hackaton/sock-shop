using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Api.Client;
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
                new Uri("http://ec2-54-224-182-6.compute-1.amazonaws.com"),
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
