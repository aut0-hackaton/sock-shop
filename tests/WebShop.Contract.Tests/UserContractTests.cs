using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using WebShop.Api.Client;
using WebShop.Api.Models.User;
using WebShop.Contract.Tests.User;

namespace WebShop.Contract.Tests
{
    [TestClass]
    public class UserContractTests
    {
        private static IMockProviderService mockProviderService;
        private static string mockProviderServiceBaseUri;

        private readonly UserConsumerPact consumerPact;

        public UserContractTests()
        {
           consumerPact = new UserConsumerPact();
        }

        [TestMethod]
        public void Able_To_Retrieve_Consumers()
        {
            mockProviderService = consumerPact.MockProviderService;
            mockProviderServiceBaseUri = consumerPact.MockProviderServiceBaseUri;
            consumerPact.MockProviderService.ClearInteractions();

            mockProviderService
                .Given("Get customers'")
                .UponReceiving("A GET request to retrieve the customers")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/customers",
                    Headers = new Dictionary<string, object>()
                    {
                        {"Accept", "application/json"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Body = 
                        new GetCustomersResponse
                        {
                            _Embedded = new Embedded
                            {
                                Customer = new Customer[]
                                {
                                    new Customer
                                    {
                                        FirstName = "Tester",
                                        LastName = "Toster"
                                    }
                                }
                            }
                        },
                    Headers = new Dictionary<string, object>()
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    }
                });

            var consumer = new WebShopApiClient(new Uri(mockProviderServiceBaseUri), "user", "password");
            var result = consumer.GetCustomers().Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GetCustomersResponse));

            mockProviderService.VerifyInteractions();
            consumerPact.Dispose();
        }
    }
}