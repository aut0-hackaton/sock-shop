namespace WebShop.Api.Models.User
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Id { get; set; }
        public Links _Links { get; set; }
    }
}