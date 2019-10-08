namespace WebShop.Api.Models.User
{
    public class UserLoginResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public UserLoginResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
