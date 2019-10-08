using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Api.Client;
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
                new Uri("http://ec2-54-224-182-6.compute-1.amazonaws.com"), 
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
