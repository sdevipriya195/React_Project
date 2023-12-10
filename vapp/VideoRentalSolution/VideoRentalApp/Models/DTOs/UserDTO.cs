using System.ComponentModel.DataAnnotations;
namespace VideoRentalApp.Models.DTOs
{
    /// <summary>
    /// This is the  DTO page where application interfaces with the user
    /// </summary>
    public class UserDTO
    {
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        public string? Phone { get; set; }


    }
}