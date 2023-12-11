using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class GetAllRentalTesting
    {
        private RentalRepository _rentalRepository;
        private MovieContext _context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("dbGetallrentals")
                .Options;

            _context = new MovieContext(dbOptions);
            _rentalRepository = new RentalRepository(_context);

            // Seed some test data
            _context.Rentals.Add(new Rental
            {
                RentalId = 1,
                RentalDate = "2023-01-01",
                RentalCost = 5.99f,
                MovieId = 1,
                Movie = new Movie
                {
                    MovieId = 1,
                    MovieName = "Movie 1",
                    GenreName = "Action",
                    DiscNumber = 101,
                    Image = "image1.jpg",
                    MovieDescription = "Description for Movie 1",
                    MovieDuration = 120,
                    MovieRating = 4.5,
                    MovieRentalCost = 5
                }
            });

            _context.Rentals.Add(new Rental
            {
                RentalId = 2,
                RentalDate = "2023-02-01",
                RentalCost = 7.99f,
                MovieId = 2,
                Movie = new Movie
                {
                    MovieId = 2,
                    MovieName = "Movie 2",
                    GenreName = "Comedy",
                    DiscNumber = 102,
                    Image = "image2.jpg",
                    MovieDescription = "Description for Movie 2",
                    MovieDuration = 110,
                    MovieRating = 3.8,
                    MovieRentalCost = 4
                }
            });

            _context.SaveChanges();
        }

        [Test]
        public void GetAllRentals_ReturnsListOfRentals()
        {
            // Act
            var result = _rentalRepository.GetAllRentals();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Rental>>(result);
            Assert.AreEqual(2, result.Count);
        }

       
    }
}

