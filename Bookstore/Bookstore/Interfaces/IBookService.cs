using System.Collections.Generic;
using Bookstore.Models.DTOS;

namespace Bookstore.Interfaces
{
    public interface IBookService
    {
        bool Add(BookDTO bookDTO);
        bool Remove(int id);
        BookDTO Update(BookDTO bookDTO);
        BookDTO GetBookById(int id);
        IEnumerable<BookDTO> GetBooks();
        List<BookDTO> GetBooksByGenre(string genre);
        List<BookDTO> GetBooksByAuthor(string author);
        List<BookDTO> GetBooksByTitle(string title);
    }
}
