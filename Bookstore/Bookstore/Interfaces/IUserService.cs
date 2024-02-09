using Bookstore.Models.DTOS;

namespace Bookstore.Interfaces
{
    public interface IUserService
    {
        UserDTO Register(UserDTO userDTO);
        UserDTO Login(UserDTO userDTO);
    }
}
