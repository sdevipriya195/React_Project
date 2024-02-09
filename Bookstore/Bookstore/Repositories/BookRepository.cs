using Bookstore.Contexts;
using Bookstore.Interfaces;
using Bookstore.Models;
using Microsoft.Extensions.Logging;

namespace Bookstore.Repositories
{
    public class BookRepository:IRepository<int,Book>
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public Book Add(Book entity)
        {
            _context.books.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Book Delete(int Key)
        {
            var booka = GetById(Key);
            if (booka != null)
            {
                _context.books.Remove(booka);
                _context.SaveChanges();
                return booka;
            }
            return null;
        }

        public IList<Book> GetAll()
        {
            if (_context.books.Count() == 0)
                return null;
            return _context.books.ToList();
        }

        public Book GetById(int Key)
        {
            var booka = _context.books.SingleOrDefault(u => u.Id == Key);
            return booka;
        }

        public Book Update(Book booka)
        {
            _context.books.Update(booka);
            _context.SaveChanges();
            return booka;
        }
    }
}
