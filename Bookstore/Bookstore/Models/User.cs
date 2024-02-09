using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IsAdmin { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
