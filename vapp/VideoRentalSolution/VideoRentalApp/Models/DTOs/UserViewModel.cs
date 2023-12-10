using System.ComponentModel.DataAnnotations;
using VideoRentalApp.Models.DTOs;

namespace VideoRentalApp.Models.DTOs
{
    /// <summary>
    /// This is the retype password object
    /// </summary>
    public class UserViewModel : UserDTO
    {
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
    }
}