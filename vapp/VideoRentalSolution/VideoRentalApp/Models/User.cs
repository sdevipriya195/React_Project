using System.ComponentModel.DataAnnotations;

namespace VideoRentalApp.Models
{
    /// <summary>
    /// This is the registration page
    /// </summary>
    public class User
    {

        [Key]
        public string Username { get; set; }

        // Storing the hashed password as a byte array for added security
        [DataType(DataType.Password)]
        public byte[] Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        // Storing a key as a byte array 
        public byte[] Key { get; set; }

        // User role (e.g.Admin, User)
        public string Role { get; set; }
        [Required]
        public string Phone { get; set; }


    }

}
