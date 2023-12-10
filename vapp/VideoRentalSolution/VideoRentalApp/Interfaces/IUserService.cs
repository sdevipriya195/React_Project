using VideoRentalApp.Models.DTOs;
using VideoRentalApp.Models.DTOs;

namespace VideoRentalApp.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Interface for Rgistration and Login
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}