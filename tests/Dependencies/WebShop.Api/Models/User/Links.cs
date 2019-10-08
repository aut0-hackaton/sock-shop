namespace WebShop.Api.Models.User
{
    public class Links
    {
        public CustomerLinks Addresses { get; set; }
        public CustomerLinks Cards { get; set; }
        public CustomerLinks Customer { get; set; }
        public CustomerLinks Self { get; set; }
    }
}