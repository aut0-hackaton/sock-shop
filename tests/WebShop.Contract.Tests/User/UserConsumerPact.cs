using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace WebShop.Contract.Tests.User
{
    public class UserConsumerPact : IDisposable
    {
        private const string ProviderName = "Userservice";
        private const string ClientName = "WebShopClient";

        public IPactBuilder PactBuilder { get; }
        public IMockProviderService MockProviderService { get; }

        public int MockServerPort => 9877;

        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}/api/";

        public UserConsumerPact()
        {
            PactBuilder = new PactBuilder
            (
                new PactConfig
                {
                    PactDir = $@"{AppDomain.CurrentDomain.BaseDirectory}\Pact",
                    LogDir = $@"{AppDomain.CurrentDomain.BaseDirectory}\Pact"
                }
            );

            PactBuilder
                .ServiceConsumer(ClientName)
                .HasPactWith(ProviderName);

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}