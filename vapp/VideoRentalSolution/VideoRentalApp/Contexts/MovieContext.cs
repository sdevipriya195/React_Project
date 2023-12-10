using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace VideoRentalApp.Contexts
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
      
    }
}