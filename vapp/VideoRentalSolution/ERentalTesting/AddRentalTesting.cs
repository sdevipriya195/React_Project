using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Exceptions;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERentalTesting
{
    [TestFixture]
    public class AddRentalTesting
    {
        private RentalRepository rentalRepository;
        private MovieContext context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbAddTestRentals")
                                .Options;

            context = new MovieContext(dbOptions);
            rentalRepository = new RentalRepository(context);
        }

        [Test]
        public void AddRental_Success()
        {
            // Arrange
            var rental = new Rental
            {
                RentalDate = DateTime.Now.ToString(),
                RentalCost = 10.0f,
                MovieId = 3
            };

            // Act
            var result = rentalRepository.AddRental(rental);

            // Assert
            Assert.AreEqual("Rental inserted successfully", result);
        }

    }
}
