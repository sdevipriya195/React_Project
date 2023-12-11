using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class UpdateRentalTesting
    {
        private RentalRepository _rentalRepository;
        private MovieContext _context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("dbupdateRental")
                .Options;

            _context = new MovieContext(dbOptions);
            _rentalRepository = new RentalRepository(_context);

            // Seed some test data
            _context.Rentals.Add(new Rental
            {
                RentalId = 1,
                RentalDate = "2023-01-01",
                RentalCost = 10.0f,
                MovieId = 1
            });

            _context.Rentals.Add(new Rental
            {
                RentalId = 2,
                RentalDate = "2023-02-01",
                RentalCost = 12.0f,
                MovieId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        [TestCase(100, 15.0f)] // Invalid RentalId
        public void UpdateRental_InvalidId_ReturnsError(int rentalId, float newRentalCost)
        {
            // Arrange
            var newRental = new Rental
            {
                RentalId = rentalId,
                RentalCost = newRentalCost
            };

            // Act
            var result = _rentalRepository.UpdateRental(newRental);

            // Assert
            Assert.AreEqual("Rental details are not updated", result);
        }

    }
}
