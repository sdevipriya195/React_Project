using Bookstore.Models.DTOS;

namespace Bookstore.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
