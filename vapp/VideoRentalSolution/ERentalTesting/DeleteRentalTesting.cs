using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Exceptions;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;
using System;
using System.Linq;


namespace ERentalTesting
{
    [TestFixture]
    public class DeleteRentalTesting
    {
        private IRentalRepository rentalRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbDeleteTestRentals")
                                .Options;

            MovieContext context = new MovieContext(dbOptions);
            rentalRepository = new RentalRepository(context);
        }

        [Test]
        public void DeleteRental_Success()
        {
            // Arrange
            var rental = new Rental
            {
                RentalId = 4,
                RentalDate = "2023-01-01",
                RentalCost = 10.00f,
                MovieId = 5
            };

            // Add the rental
            rentalRepository.AddRental(rental);

            // Act
            var result = rentalRepository.DeleteRental(1);

            // Assert
            Assert.AreEqual("Rental is not available", result);
        }
    }
}
