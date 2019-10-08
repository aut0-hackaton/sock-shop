using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebShop.Api.Configuration;
using WebShop.Api.Models.Orders;
using WebShop.Api.Models.Payment;
using WebShop.Api.Models.User;

namespace WebShop.Api.Client
{
    public class WebShopApiClient : IWebShopClient
    {
        private readonly Func<HttpClient> createApiClient;
        private readonly IDictionary<string, string> headers = new Dictionary<string, string>();

        public WebShopApiClient(HttpClient client)
        {
            createApiClient = () => client;
        }

        public WebShopApiClient(Uri endpoint, string username, string password)
        {
            createApiClient = () =>
            {
                var handler = new HttpClientHandler();

                var client = new HttpClient(handler)
                {
                    BaseAddress = endpoint ?? AppSettings.Instance.Endpoint
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                (
                    "Basic", 
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"))
                ); 

                foreach (var (key, value) in headers)
                {
                    client.DefaultRequestHeaders.Add(key, value);
                }

                return client;
            };
        }

        public void SetRequestHeader(string name, string value)
        {
            headers[name] = value;
        }

        public async Task<WebShopApiClient> Login(string username, string password)
        {
            var auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

            var client = createApiClient();

            client.DefaultRequestHeaders.Authorization = auth;
            var response = await client.GetAsync("/login");

            return response.IsSuccessStatusCode
                ? new WebShopApiClient(client)
                : null;
        }

        public async Task<GetCustomersResponse> GetCustomers()
        {
            using (var client = createApiClient())
            {
                var response = await client.GetAsync("/customers");
                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<GetCustomersResponse>(await response.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public async Task<GetHealthResponse> GetHealth()
        {
            using (var client = createApiClient())
            {
                var response = await client.GetAsync("/health");
                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<GetHealthResponse>(await response.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public async Task<List<GetOrdersResponse>> GetOrders()
        {
            using (var client = createApiClient())
            {
                var response = await client.GetAsync("/orders");
                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<List<GetOrdersResponse>>(await response.Content.ReadAsStringAsync())
                    : null;
            }
        }
    }
}
