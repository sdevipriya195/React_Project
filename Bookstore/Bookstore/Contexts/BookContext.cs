using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bookstore.Contexts
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
