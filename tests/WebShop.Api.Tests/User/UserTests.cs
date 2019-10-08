using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Api.Client;
using WebShop.Api.Configuration;
using WebShop.Api.Models.User;

namespace WebShop.Api.Tests.User
{
    [TestClass]
    public class UserTests
    {
        private readonly IWebShopClient webShopClient;

        public UserTests()
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
        public void Possible_To_Login_With_Valid_Credentials()
        {
            var response = webShopClient.Login("user", "password").Result;

            Assert.IsTrue(response.Success, "Login was not successful");
            Assert.AreEqual("Cookie is set", response.Message);
        }

        [TestMethod]
        public void Possible_To_Get_Customer()
        {
            var response = webShopClient.GetCustomers().Result;

            Assert.IsInstanceOfType(response, typeof(GetCustomersResponse));
            Assert.IsNotNull(response._Embedded);
        }
    }
}
