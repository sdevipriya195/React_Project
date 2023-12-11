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
    public class GetRentalByIdTesting
    {
        private RentalRepository _rentalRepository;
        private MovieContext _context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("dbGetByIdRental")
                .Options;

            _context = new MovieContext(dbOptions);
            _rentalRepository = new RentalRepository(_context);

            // Seed some test data
            _context.Rentals.Add(new Rental
            {
                RentalId = 1,
                RentalDate = "2023-01-01",
                RentalCost = 5.99f,
                MovieId = 1
            });

            _context.Rentals.Add(new Rental
            {
                RentalId = 2,
                RentalDate = "2023-02-01",
                RentalCost = 6.99f,
                MovieId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetRentalById_ValidId_ReturnsRental(int rentalId)
        {
            // Act
            var result = _rentalRepository.GetRentalById(rentalId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(rentalId, result.RentalId);
        }

        [Test]
        [TestCase(100)] // Invalid RentalId
        [TestCase(-1)]  // Invalid RentalId
        public void GetRentalById_InvalidId_ReturnsNull(int rentalId)
        {
            // Act
            var result = _rentalRepository.GetRentalById(rentalId);

            // Assert
            Assert.IsNull(result);
        }

    }
}
