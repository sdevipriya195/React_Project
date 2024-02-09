using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Interfaces;
using Bookstore.Models;
using Bookstore.Models.DTOS;

namespace Bookstore.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<int, Book> _bookRepository;

        public BookService(IRepository<int, Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public bool Add(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                throw new ArgumentNullException(nameof(bookDTO));
            }

            var bookEntity = new Book
            {
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Genre = bookDTO.Genre,
                Isbn = bookDTO.Isbn,
                PublishDate = bookDTO.PublishDate,
                UserName = bookDTO.UserName
            };

            _bookRepository.Add(bookEntity);

            return true;
        }

        public bool Remove(int id)
        {
            var removedBook = _bookRepository.Delete(id);

            return removedBook != null; 
        }

        public BookDTO Update(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                throw new ArgumentNullException(nameof(bookDTO));
            }

            var updatedBookEntity = new Book
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Genre = bookDTO.Genre,
                Isbn = bookDTO.Isbn,
                PublishDate = bookDTO.PublishDate,
                UserName = bookDTO.UserName
            };

            var updatedBook = _bookRepository.Update(updatedBookEntity);

            var updatedBookDTO = new BookDTO
            {
                Id = updatedBook.Id,
                Title = updatedBook.Title,
                Author = updatedBook.Author,
                Genre = updatedBook.Genre,
                Isbn = updatedBook.Isbn,
                PublishDate = updatedBook.PublishDate,
                UserName = updatedBook.UserName
            };

            return updatedBookDTO;
        }

        public BookDTO GetBookById(int id)
        {
            var bookEntity = _bookRepository.GetById(id);

            if (bookEntity != null)
            {
                var bookDTO = new BookDTO
                {
                    Id = bookEntity.Id,
                    Title = bookEntity.Title,
                    Author = bookEntity.Author,
                    Genre = bookEntity.Genre,
                    Isbn = bookEntity.Isbn,
                    PublishDate = bookEntity.PublishDate,
                    UserName = bookEntity.UserName
                };

                return bookDTO;
            }

            return null;
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var allBooks = _bookRepository.GetAll();

            if (allBooks != null)
            {
                var bookDTOs = allBooks.Select(bookEntity => new BookDTO
                {
                    Id = bookEntity.Id,
                    Title = bookEntity.Title,
                    Author = bookEntity.Author,
                    Genre = bookEntity.Genre,
                    Isbn = bookEntity.Isbn,
                    PublishDate = bookEntity.PublishDate,
                    UserName = bookEntity.UserName
                });

                return bookDTOs;
            }

            return Enumerable.Empty<BookDTO>();
        }

        public List<BookDTO> GetBooksByGenre(string genre)
        {
            var allBooks = _bookRepository.GetAll();

            if (allBooks != null)
            {
                var filteredBooks = allBooks
                    .Where(bookEntity => string.Equals(bookEntity.Genre, genre, StringComparison.OrdinalIgnoreCase))
                    .Select(bookEntity => new BookDTO
                    {
                        Id = bookEntity.Id,
                        Title = bookEntity.Title,
                        Author = bookEntity.Author,
                        Genre = bookEntity.Genre,
                        Isbn = bookEntity.Isbn,
                        PublishDate = bookEntity.PublishDate,
                        UserName = bookEntity.UserName
                    });

                return filteredBooks.ToList();
            }

            return new List<BookDTO>();
        }

        public List<BookDTO> GetBooksByAuthor(string author)
        {
            var allBooks = _bookRepository.GetAll();

            if (allBooks != null)
            {
                var filteredBooks = allBooks
                    .Where(bookEntity => string.Equals(bookEntity.Author, author, StringComparison.OrdinalIgnoreCase))
                    .Select(bookEntity => new BookDTO
                    {
                        Id = bookEntity.Id,
                        Title = bookEntity.Title,
                        Author = bookEntity.Author,
                        Genre = bookEntity.Genre,
                        Isbn = bookEntity.Isbn,
                        PublishDate = bookEntity.PublishDate,
                        UserName = bookEntity.UserName
                    });

                return filteredBooks.ToList();
            }

            return new List<BookDTO>();
        }

        public List<BookDTO> GetBooksByTitle(string title)
        {
            var allBooks = _bookRepository.GetAll();

            if (allBooks != null)
            {
                var filteredBooks = allBooks
                    .Where(bookEntity => string.Equals(bookEntity.Title, title, StringComparison.OrdinalIgnoreCase))
                    .Select(bookEntity => new BookDTO
                    {
                        Id = bookEntity.Id,
                        Title = bookEntity.Title,
                        Author = bookEntity.Author,
                        Genre = bookEntity.Genre,
                        Isbn = bookEntity.Isbn,
                        PublishDate = bookEntity.PublishDate,
                        UserName = bookEntity.UserName
                    });

                return filteredBooks.ToList();
            }

            return new List<BookDTO>();
        }
    }
}

