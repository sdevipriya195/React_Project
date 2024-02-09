namespace Bookstore.Models.DTOS
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IsAdmin { get; set; }
        public string? Token { get; set; }
    }
}
