using System.Threading.Tasks;
using WebShop.Api.Models.Payment;
using WebShop.Api.Models.User;

namespace WebShop.Api.Client
{
    public interface IWebShopClient
    {
        Task<UserLoginResponse> Login(string username, string password);

        Task<GetCustomersResponse> GetCustomers();

        Task<GetHealthResponse> GetHealth();
    }
}
