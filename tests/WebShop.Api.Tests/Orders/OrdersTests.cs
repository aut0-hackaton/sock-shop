using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Api.Client;
using WebShop.Api.Configuration;

namespace WebShop.Api.Tests.Orders
{
    [TestClass]
    public class OrdersTests
    {
        private readonly IWebShopClient webShopClient;

        public OrdersTests()
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
        public void Possible_To_Get_Orders_If_Signed_In()
        {
            var response = webShopClient
                .Login("user", "password")
                .Result
                .GetOrders()
                .Result;

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Not_Possible_To_Get_Orders_If_Not_Signed_In()
        {
            var response = webShopClient
                .GetOrders()
                .Result;

            Assert.IsNull(response);
        }
    }
}
